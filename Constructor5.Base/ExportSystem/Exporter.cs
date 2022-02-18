using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.LocalizationSystem;
using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using Constructor5.Core;
using s4pi.Extensions;
using s4pi.Interfaces;
using s4pi.Package;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Constructor5.Base.Export
{
    public class Exporter
    {
        public static Exporter Current { get; private set; }
        public string PackageFile { get; set; }
        public STBLBuilder STBLBuilder { get; private set; }

        public static void Create() => Current = new Exporter();

        public static void StartExport(string packageFile)
        {
            Current = new Exporter() { PackageFile = packageFile };
            Current.Export();
        }

        public void AddContextSpecificElement(Element element)
        {
            if (ExportedElements.Contains(element))
            {
                return;
            }

            ContextSpecificElementsToExport.Add(element);
        }

        public void AddError(Element element, string message)
        {
            var fullMessage = new StringBuilder();
            fullMessage.AppendLine(TextStringManager.Get(message));
            fullMessage.AppendLine(TextStringManager.Get("UserErrorElement").Replace("{id}", element?.UserFacingId ?? "(No Element)").Replace("{label}", element?.Label ?? "(No Element)"));
            fullMessage.AppendLine("---");

            ErrorBuilder.AppendLine(fullMessage.ToString());
        }

        public void Export()
        {
            ElementSaver.SaveScheduled();

            STBLBuilder = new STBLBuilder();

            ExportElements();
            ExportPython();
            ExportSTBL();
            ExportImports();
            WritePackage();
            DeleteContextSpecificElements();

            var error = ErrorBuilder.ToString();
            if (!string.IsNullOrEmpty(error))
            {
                Results.ErrorMessage = ErrorBuilder.ToString();
            }

            Hooks.Location<IOnExportComplete>(x => x.OnExportComplete(Results));
        }

        public void ForceExportContextSpecific(Element element) => ContextSpecificElementsToExport.Add(element);

        public void QueueFile(string fileName, Stream stream) => QueuedFiles.Add(fileName, stream);

        public void QueueFile(string hexType, string hexGroup, string hexInstance, Stream stream)
            => QueuedFiles.Add($"{hexType}!{hexGroup}!{hexInstance}", stream);

        private Exporter()
        { }

        private HashSet<Element> ContextSpecificElementsToExport { get; } = new HashSet<Element>();

        private StringBuilder ErrorBuilder { get; } = new StringBuilder();

        private HashSet<Element> ExportedElements { get; } = new HashSet<Element>();

        private Dictionary<string, Stream> QueuedFiles { get; } = new Dictionary<string, Stream>();

        private ExportResultsData Results { get; } = new ExportResultsData();

        private void DeleteContextSpecificElements()
        {
            foreach (var element in ElementManager.GetAll())
            {
                if (!element.IsTemporary)
                {
                    if (!element.IsContextSpecific || ExportedElements.Contains(element))
                    {
                        continue;
                    }
                }

                ElementManager.Delete(element);
            }
        }

        private void ExportElements()
        {
            var elements = (IEnumerable<Element>)ElementManager.GetAll(false);

            do
            {
                foreach (var element in elements.ToArray())
                {
                    if (element is IExportableElement exportableElement)
                    {
                        exportableElement.OnExport();
                        ExportedElements.Add(element);
                        ContextSpecificElementsToExport.Remove(element);
                    }
                }

                elements = ContextSpecificElementsToExport;
            } while (elements.Count() > 0);
        }

        private void ExportImports()
        {
            foreach (var file in Directory.GetFiles(Project.GetDirectory("Imports")))
            {
                QueueFile(Path.GetFileNameWithoutExtension(file), File.Open(file, FileMode.Open, FileAccess.Read));
            }
        }

        private void ExportPython()
        {
            if (PythonBuilder.Current == null)
            {
                return;
            }

            var fileName = $"{Project.GetDirectory("Python")}/{Project.Id}.py";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllText(fileName, PythonBuilder.Current.GetContent());

            RunPythonScript(fileName);
        }

        private void ExportSTBL()
        {
            void QueueSTBL(string languageCode)
            {
                var stbl = new StblResource.StblResource(0, null);

                foreach (var stblString in STBLBuilder.Strings)
                {
                    stbl.Entries.Add(new StblResource.StringEntry(0, null) { KeyHash = stblString.Key, StringValue = stblString.Value });
                }

                //AddCustomStblStrings(stbl);

                var hexCode = FNVHasher.FNV64($"{Project.Id}:STBLStrings", true).ToString("X").PadLeft(16, '0');
                hexCode = languageCode + hexCode.Substring(2, hexCode.Length - 2);

                var memoryStream = new MemoryStream();
                stbl.Stream.CopyTo(memoryStream);
                QueuedFiles.Add($"220557DA!0!{hexCode:X}", memoryStream);
            }

            QueueSTBL("00");
            QueueSTBL("02");
            QueueSTBL("03");
            QueueSTBL("04");
            QueueSTBL("05");
            QueueSTBL("06");
            QueueSTBL("07");
            QueueSTBL("08");
            QueueSTBL("0B");
            QueueSTBL("0C");
            QueueSTBL("0D");
            QueueSTBL("0E");
            QueueSTBL("0F");
            QueueSTBL("10");
            QueueSTBL("11");
            QueueSTBL("12");
            QueueSTBL("13");
            QueueSTBL("15");
        }

        private TGIN GetOldTGIN(string fileName)
        {
            var tgi = Path.GetFileNameWithoutExtension(fileName)?.Split('_').Skip(1).ToArray();
            return new TGIN { ResType = uint.Parse(tgi[0], NumberStyles.HexNumber), ResGroup = uint.Parse(tgi[1], NumberStyles.HexNumber), ResInstance = ulong.Parse(tgi[2], NumberStyles.HexNumber) };
        }

        private TGIN GetTGIN(string fileName)
        {
            var tgi = Path.GetFileNameWithoutExtension(fileName).Split('!');
            return new TGIN { ResType = uint.Parse(tgi[0], NumberStyles.HexNumber), ResGroup = uint.Parse(tgi[1], NumberStyles.HexNumber), ResInstance = ulong.Parse(tgi[2], NumberStyles.HexNumber) };
        }

        private void RunPythonScript(string fileName)
        {
            var exePath = PythonInstallationHelper.GetPath();

            if (exePath == null)
            {
                AddError(null, "PythonNotInstalled");
                return;
            }

            var directory = Path.GetDirectoryName(fileName) ?? throw new NullReferenceException();

            var start = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"-m compileall {Path.GetFileName(fileName)}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = directory
            };

            //var result = PythonBuilder.Current.GetContent();
            using (var process = Process.Start(start))
            {
                using (var reader = process.StandardOutput)
                {
                    Console.Write(reader.ReadToEnd());
                }
            }

            var cacheFile = $"{directory}/__pycache__/{Path.GetFileNameWithoutExtension(fileName)}.cpython-37.pyc";

            var newFile = $"{directory}/{Path.GetFileNameWithoutExtension(fileName)}.pyc";
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
            File.Move(cacheFile, newFile);
            Directory.Delete($"{directory}/__pycache__");

            var zipFileName = $"{Path.GetDirectoryName(PackageFile)}/{Path.GetFileNameWithoutExtension(PackageFile)}.ts4script";
            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }

            ZipFile.CreateFromDirectory(directory, zipFileName);
        }

        private void WritePackage()
        {
            var package = Package.NewPackage(0);

            foreach (var file in QueuedFiles)
            {
                var tgin = file.Key.Contains("!") ? GetTGIN(file.Key) : GetOldTGIN(file.Key);
                IResourceKey resourceKey = (TGIBlock)tgin;
                var indexEntry = package.AddResource(resourceKey, file.Value, true);
                if (indexEntry != null)
                {
                    indexEntry.Compressed = 0x5A42;
                }
            }

            package.SaveAs(PackageFile);
            package.Dispose();

            foreach(var file in QueuedFiles)
            {
                file.Value.Close();
            }
        }
    }
}