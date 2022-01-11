using System.Collections.Generic;

namespace Constructor5.DebugTools.PresetExtractor
{
    public class PresetInstruction
    {
        public static string MainPresetDirectory { get; } = @"D:\Game Resources\The Sims\XML";

        public string ExportDirectory { get; set; }
        public string ExportFileName { get; set; }
        public string NameXMLTag { get; set; }
        public string SearchString { get; set; }
        public string XMLDirectory { get; set; }

        public static PresetInstruction[] CreateBatch(string xmlDirectory, string exportDirectory, string allName, string nameTag, Dictionary<string, string> searchStrings)
        {
            var result = new List<PresetInstruction>();

            var allInstruction = new PresetInstruction
            {
                ExportDirectory = exportDirectory,
                ExportFileName = allName,
                NameXMLTag = nameTag,
                XMLDirectory = xmlDirectory
            };
            result.Add(allInstruction);

            foreach(var searchString in searchStrings)
            {
                result.Add(new PresetInstruction
                {
                    ExportDirectory = exportDirectory,
                    ExportFileName = searchString.Key,
                    NameXMLTag = nameTag,
                    SearchString = searchString.Value,
                    XMLDirectory = xmlDirectory
                });
            }

            return result.ToArray();
        }
    }
}
