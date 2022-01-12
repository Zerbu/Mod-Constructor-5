using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

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

            /*RunInstructions(InstructionBatches.Traits);
            RunInstructions(InstructionBatches.Animation);
            RunInstructions(InstructionBatches.AspirationCategories);
            RunInstructions(InstructionBatches.AspirationTracks);
            RunInstructions(InstructionBatches.Balloon);
            RunInstructions(InstructionBatches.Buffs);
            RunInstructions(InstructionBatches.Loot);
            RunInstructions(InstructionBatches.Objectives);
            RunInstructions(InstructionBatches.ObjectiveSets);
            RunInstructions(InstructionBatches.PieMenuCategories);
            RunInstructions(InstructionBatches.Rewards);
            RunInstructions(InstructionBatches.SituationGoals);
            RunInstructions(InstructionBatches.SituationGoalSets);

            RunInstructions(InstructionBatches.Commodities);
            RunInstructions(InstructionBatches.SituationJobs);
            RunInstructions(InstructionBatches.Situations);

            RunInstructions(InstructionBatches.Interactions);

            RunInstructions(InstructionBatches.Broadcasters);
            RunInstructions(InstructionBatches.SimFilters);
            RunInstructions(InstructionBatches.Skills);*/
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

                /*if (Path.GetFileName(packDir) != "EP11")
                {
                    continue;
                }*/

                var typeDir = $"{packDir}/{instruction.XMLDirectory}";
                if (!Directory.Exists(typeDir))
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