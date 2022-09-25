using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ProjectSystem;
using Constructor5.Core;
using s4pi.ImageResource;
using s4pi.Package;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Constructor5.Base.ElementSystem
{
    public static class PresetImporter
    {
        public static PresetGroup Import(string fileName, string presetFolder, string tuningType)
        {
            var package = (Package)Package.OpenPackage(0, fileName);

            var newGroup = new PresetGroup
            {
                Label = Path.GetFileNameWithoutExtension(fileName)
            };

            var indexEntries = package.FindAll(r => r.ResourceType == FNVHasher.FNV32(tuningType, false));
            foreach(var indexEntry in indexEntries)
            {
                var preset = new Preset();

                var xml = new StreamReader(package.GetResource(indexEntry)).ReadToEnd();

                using (var reader = XmlReader.Create(new StringReader(xml)))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            preset.Value = reader.GetAttribute("s");
                            preset.Label = reader.GetAttribute("n");
                            newGroup.Presets.Add(preset);
                            break;
                        }
                    }
                }
            }

            XmlSaver.SaveFile(newGroup, DirectoryUtility.GetUserDirectory($"Presets/{presetFolder}/{newGroup.Label}.Presets.xml"));

            return newGroup;
        }
    }
}
