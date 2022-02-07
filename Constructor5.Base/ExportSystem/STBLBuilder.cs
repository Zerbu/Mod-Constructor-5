using Constructor5.Base.ProjectSystem;
using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Base.ExportSystem
{
    public class STBLBuilder
    {
        public List<StringValue> Strings { get; } = new List<StringValue>();

        public uint? GetKey(string text, string guid, STBLString property = null)
        {
            if (text.StartsWith("0x"))
            {
                var result = CommentUtility.StripComment(text).Replace("0x", string.Empty);
                return uint.TryParse(result, NumberStyles.HexNumber, null, out var outputInt) ? outputInt : 0;
            }

            if (property != null)
            {
                var existing = Strings.FirstOrDefault(x => x.UsedByStrings.Contains(property));
                if (existing != null)
                {
                    return existing.Key;
                }
            }

            var existingValue = Strings.FirstOrDefault(x => x.Value == text);
            if (existingValue != null)
            {
                if (property != null)
                {
                    existingValue.UsedByStrings.Add(property);
                }
                
                return existingValue.Key;
            }

            var newKey = FNVHasher.FNV32($"{Project.Id}:{guid}", true);
            var newString = new StringValue()
            {
                Key = newKey,
                Value = text
            };
            if (property != null)
            {
                newString.UsedByStrings.Add(property);
            }
            
            Strings.Add(newString);

            return newKey;
        }

        public uint? GetKey(STBLString property)
        {
            if (string.IsNullOrEmpty(property.CustomText))
            {
                return null;
            }

            return GetKey(property.CustomText, property.Guid, property);
        }

        public class StringValue
        {
            public uint Key { get; set; }
            public List<STBLString> UsedByStrings { get; } = new List<STBLString>();
            public string Value { get; set; }
        }

        internal STBLBuilder()
        {
        }
    }
}
