using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Constructor5.DebugTools.PresetExtractor
{
    public class Program
    {
        public static uint GetSTBLKey(TuningBase tuningPart, string tunableName)
        {
            foreach (var tunable in tuningPart.Tunables)
            {
                if (tunable.Name == tunableName && tunable.Value?.StartsWith("0x", StringComparison.Ordinal) == true)
                {
                    return uint.Parse(tunable.Value.Substring(2, tunable.Value.Length - 2), NumberStyles.HexNumber);
                }

                var childValue = GetSTBLKey(tunable, tunableName);
                if (childValue != 0)
                {
                    return childValue;
                }
            }

            return 0;
        }

        public static void Main(string[] args)
        {
            foreach(var batch in typeof(InstructionBatches).GetProperties())
            {
                var value = (PresetInstruction[])batch.GetValue(null);
                RunInstructions(value);
            }

            ExtractTags();
            Console.ReadKey();
        }

        private static void ExtractTags()
        {
            var tagsFile = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Mod Development\XML\BG\tun\S4_03B33DDF_00000000_D89CB9186B79ACB7.xml";

            var funcTags = new PresetGroup() { Label = "Function Tags" };
            var buildTags = new PresetGroup() { Label = "Build Category Tags" };
            var buyTags = new PresetGroup() { Label = "Buy Category Tags" };
            var recipeTags = new PresetGroup() { Label = "Recipe Tags" };

            using (var reader = XmlReader.Create(tagsFile))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    var ev = reader.GetAttribute("ev");
                    if (ev == null)
                    {
                        continue;
                    }

                    var value = reader.ReadInnerXml();
                    if (value.StartsWith("Func_"))
                    {
                        funcTags.Presets.Add(new Preset { Value = value });
                    }
                    if (value.StartsWith("BuyCat"))
                    {
                        buyTags.Presets.Add(new Preset { Value = value });
                    }
                    if (value.StartsWith("Build"))
                    {
                        buildTags.Presets.Add(new Preset { Value = value });
                    }
                    if (value.StartsWith("Recipe_"))
                    {
                        recipeTags.Presets.Add(new Preset { Value = value });
                    }
                }
            }

            void Output(string dirName, string fileName, PresetGroup presetGroup)
            {
                var fullPath = $"Presets/{dirName}/{fileName}.Presets.xml";
                Console.WriteLine(fullPath);
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath) ?? throw new InvalidOperationException());
                XmlSaver.SaveFile(presetGroup, fullPath);
            }

            Output("ObjectTag", "BuildCategoryTags", buildTags);
            Output("ObjectTag", "BuyCategoryTags", buyTags);
            Output("ObjectTag", "FunctionTags", funcTags);
            Output("RecipeTag", "RecipeTags", recipeTags);
            //Output("ObjectTag", "CollectionTags", collectionTags);
        }

        private static readonly List<string> TestUnsafeTypes =
            new List<string> { "SocialMixerInteraction", "ClubSocialMixerInteraction" };

        private static void RunInstruction(PresetInstruction instruction)
        {
            Console.WriteLine($"Starting instruction: {instruction.ExportFileName}");

            var presetGroup = new PresetGroup();

            if (!instruction.SplitByPack)
            {
                var fullPath = $"Presets/{instruction.ExportDirectory}/{instruction.ExportFileName.Replace(" ", string.Empty)}.Presets.xml";
                if (File.Exists(fullPath))
                {
                    return;
                }
            }

            foreach (var packDir in Directory.GetDirectories(PresetInstruction.MainPresetDirectory))
            {
                if (instruction.SplitByPack)
                {
                    presetGroup = new PresetGroup();
                }

                var fullPath = $"Presets/{instruction.ExportDirectory}/{instruction.ExportFileName.Replace(" ", string.Empty)}{Path.GetFileNameWithoutExtension(packDir)}.Presets.xml";
                if (File.Exists(fullPath))
                {
                    continue;
                }

                /*if (Path.GetFileName(packDir) != "BG")
                {
                    continue;
                }*/

                var typeDir = $"{packDir}/{instruction.XMLDirectory}";
                if (!Directory.Exists(typeDir))
                {
                    continue;
                }
                var typeDirName = Path.GetFileName(typeDir).ToLower();
                if (typeDirName != "recipe")
                {
                    continue;
                }
                Console.WriteLine($"Checking directory: {typeDir}");
                foreach (var xmlFile in Directory.GetFiles(typeDir, "*.xml"))
                {
                    var xmlContent = File.ReadAllText(xmlFile);
                    if (!string.IsNullOrEmpty(instruction.SearchString) && !xmlContent.ToLower().Contains(instruction.SearchString.ToLower()))
                    {
                        continue;
                    }

                    var tuning = XmlLoader.LoadFile<TuningHeader>(xmlFile);
                    if (instruction.SubType != null && tuning.Class.ToLower() != instruction.SubType.ToLower())
                    {
                        continue;
                    }

                    var stblValue = STBLHelper.TS4Handler.GetString(GetSTBLKey(tuning, instruction.NameXMLTag));

                    var label = stblValue == null ? tuning.Name : $"{stblValue} ({tuning.Name})";

                    var preset = new Preset { Label = label, Value = tuning.InstanceKey.ToString() };

                    if (TestUnsafeTypes.Contains(tuning.Class) || tuning.Class.ToLower().Contains("picker"))
                    {
                        preset.TagsString = "TestUnsafe";
                    }

                    presetGroup.Presets.Add(preset);

                    presetGroup.Label = instruction.ExportFileName;

                    if (instruction.SplitByPack)
                    {
                        presetGroup.Label = $"{instruction.ExportFileName} {Path.GetFileNameWithoutExtension(packDir)}";
                    }
                }

                if (instruction.SplitByPack && presetGroup.Presets.Count > 0)
                {
                    Console.WriteLine(fullPath);

                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath) ?? throw new InvalidOperationException());

                    XmlSaver.SaveFile(presetGroup, fullPath);
                }
            }

            if (!instruction.SplitByPack)
            {
                var fullPath = $"Presets/{instruction.ExportDirectory}/{instruction.ExportFileName.Replace(" ", string.Empty)}.Presets.xml";

                Console.WriteLine(fullPath);

                Directory.CreateDirectory(Path.GetDirectoryName(fullPath) ?? throw new InvalidOperationException());

                XmlSaver.SaveFile(presetGroup, fullPath);
            }
        }

        private static void RunInstructions(PresetInstruction[] instructions)
        {
            foreach (var instruction in instructions)
            {
                RunInstruction(instruction);
            }
        }
    }
}