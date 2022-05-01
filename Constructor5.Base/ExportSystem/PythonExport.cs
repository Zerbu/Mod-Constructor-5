using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ExportSystem
{
    public class PythonExport
    {
        internal void ExportPython()
        {
            var pythonDir = Project.GetProjectDirectory("Python");

            if (PythonBuilder.Current != null)
            {
                var fileName = $"{pythonDir}/{Project.Id}.py";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.WriteAllText(fileName, PythonBuilder.Current.GetContent());
                RunPythonScript(fileName);
            }

            foreach (var scriptFile in Directory.GetFiles(Project.GetProjectDirectory("Imports"), "*.py"))
            {
                RunPythonScript(scriptFile);
            }

            CreateZipFile();

            foreach(var file in FilesToDelete)
            {
                File.Delete(file);
            }

            PythonBuilder.Clear();
        }

        private void CreateZipFile()
        {
            var pythonDir = Project.GetProjectDirectory("Python");

            if (Directory.Exists(pythonDir) && Directory.EnumerateFileSystemEntries(pythonDir).Any())
            {
                var zipFileName = $"{Path.GetDirectoryName(Exporter.Current.PackageFile)}/{Path.GetFileNameWithoutExtension(Exporter.Current.PackageFile)}.ts4script";
                if (File.Exists(zipFileName))
                {
                    File.Delete(zipFileName);
                }
                ZipFile.CreateFromDirectory(pythonDir, zipFileName);
            }
        }

        private void RunPythonScript(string fileName)
        {
            var exePath = PythonInstallationHelper.GetPath();

            if (exePath == null)
            {
                Exporter.Current.AddError(null, "PythonNotInstalled");
                return;
            }

            try
            {
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

                var newFile = $"{Project.GetProjectDirectory("Python")}/{Path.GetFileNameWithoutExtension(fileName)}.pyc";
                if (File.Exists(newFile))
                {
                    File.Delete(newFile);
                }
                File.Move(cacheFile, newFile);
                Directory.Delete($"{directory}/__pycache__");

                FilesToDelete.Add(newFile);
            }
            catch (Exception ex)
            {
                Exporter.Current.AddError(null, $"PythonCompileError");
                Exporter.Current.AddError(null, ex.Message);
            }
        }

        private List<string> FilesToDelete { get; } = new List<string>();
    }
}
