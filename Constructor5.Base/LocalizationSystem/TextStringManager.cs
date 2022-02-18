using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace Constructor5.Base.LocalizationSystem
{
    public static class TextStringManager
    {
        public static string Get(string key)
        {
            if (TextStrings == null)
            {
                TextStrings = (LocalizableTextStrings)XmlLoader.LoadStream(typeof(LocalizableTextStrings),
                    typeof(TextStringManager).Assembly.GetManifestResourceStream("Constructor5.Base.LocalizationSystem.LocalizableTextStringsXML.xml"));
                foreach(var str in TextStrings.Strings)
                {
                    Cache.Add(str.Key, str.Value);
                }
            }

            if (key == null)
            {
                return null;
            }

            if (key.StartsWith("{nl}"))
            {
                return key.Split(new[] { "{nl}" }, StringSplitOptions.None)[1];
            }

            if (Cache.ContainsKey(key))
            {
                return Cache[key];
            }

            Hooks.Location<IOnUnlocalizableStringDetected>(x => x.OnUnlocalizableStringDetected(key));

#if DEBUG
            return $"*{key}*";
#endif

#pragma warning disable CS0162 // Unreachable code detected
            return key;
#pragma warning restore CS0162 // Unreachable code detected
        }

        public static bool HasKey(string newKey) => Cache.ContainsKey(newKey);

        public static Dictionary<string, string> GetAll()
        {
            var result = new Dictionary<string, string>();
            foreach(var str in TextStrings.Strings)
            {
                result.Add(str.Key, str.Value);
            }
            return result;
        }

        private static Dictionary<string, string> Cache { get; } = new Dictionary<string, string>();
        private static LocalizableTextStrings TextStrings { get; set; }
    }
}
