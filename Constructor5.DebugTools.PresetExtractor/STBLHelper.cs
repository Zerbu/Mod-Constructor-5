using s4pi.Package;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Constructor5.DebugTools.PresetExtractor
{
    public class STBLHelper
    {
        public static STBLHelper TS4Handler { get; } = CreateTS4Handler();

        public List<StblResource.StblResource> StblResources { get; } = new List<StblResource.StblResource>();

        public string GetString(uint key)
        {
            return (from resource in StblResources
                    select resource.Entries.FirstOrDefault(x => x.KeyHash == key)
                    into entry
                    where entry != null
                    select entry.StringValue).FirstOrDefault();
        }

        private static STBLHelper CreateTS4Handler()
        {
            var result = new STBLHelper();

            // FOR DEBUG PURPOSES ONLY - this code is NOT prepared for the public (it will crash if the user doesn't have all the packs installed or if The Sims 4 is stored in a different directory)
            /*var directories = new List<string>()
                                  {
                                      "D:\\Games\\The Sims 4\\Data\\Client",
                                      "D:\\Games\\The Sims 4\\EP01",
                                      "D:\\Games\\The Sims 4\\EP02",
                                      "D:\\Games\\The Sims 4\\EP03",
                                      "D:\\Games\\The Sims 4\\EP04",
                                      "D:\\Games\\The Sims 4\\EP05",
                                      "D:\\Games\\The Sims 4\\EP06",
                                      "D:\\Games\\The Sims 4\\GP01",
                                      "D:\\Games\\The Sims 4\\GP02",
                                      "D:\\Games\\The Sims 4\\GP03",
                                      "D:\\Games\\The Sims 4\\GP04",
                                      "D:\\Games\\The Sims 4\\GP06",
                                      "D:\\Games\\The Sims 4\\GP07",
                                      "D:\\Games\\The Sims 4\\SP01",
                                      "D:\\Games\\The Sims 4\\SP02",
                                      "D:\\Games\\The Sims 4\\SP03",
                                      "D:\\Games\\The Sims 4\\SP04",
                                      "D:\\Games\\The Sims 4\\SP05",
                                      "D:\\Games\\The Sims 4\\SP06",
                                      "D:\\Games\\The Sims 4\\SP07",
                                      "D:\\Games\\The Sims 4\\SP08",
                                      "D:\\Games\\The Sims 4\\SP09",
                                      "D:\\Games\\The Sims 4\\SP10",
                                      "D:\\Games\\The Sims 4\\SP11",
                                      "D:\\Games\\The Sims 4\\SP12",
                                      "D:\\Games\\The Sims 4\\SP13",
                                      "D:\\Games\\The Sims 4\\SP14",
                                  };*/

            foreach (var file in Directory.GetFiles(@"C:\Program Files\EA Games\The Sims 4", "*.package", SearchOption.AllDirectories))
            {
                if (Path.GetFileNameWithoutExtension(file).StartsWith("Strings"))
                {
                    result.LoadResourcesFromPackage((Package)Package.OpenPackage(0, file, false));
                }
            }

            return result;
        }

        private void LoadResourcesFromPackage(Package package)
        {
            var indexEntryList = package.FindAll(r => r.ResourceType == 0x220557DA);
            foreach (var indexEntry in indexEntryList)
            {
                try
                {
                    StblResources.Add(new StblResource.StblResource(0, package.GetResource(indexEntry)));
                }
                catch
                {
                }
            }
        }
    }
}
