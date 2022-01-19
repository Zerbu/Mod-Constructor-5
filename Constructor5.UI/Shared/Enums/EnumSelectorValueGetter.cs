using Constructor5.Base.LocalizationSystem;
using System;
using System.Collections.Generic;

namespace Constructor5.UI.Shared
{
    public static class EnumSelectorValueGetter
    {
        public static IEnumerable<EnumSelectorValue> GetValues(Type type, EnumSelectorReplaceDictionary displayText)
        {
            var result = new List<EnumSelectorValue>();

            if (type == null || displayText == null)
            {
                return result;
            }

            foreach (var value in type.GetEnumValues())
            {
                var valueString = value.ToString();
                result.Add(new EnumSelectorValue
                {
                    Value = value,
                    DisplayText = displayText.TryGetValue(value.ToString(), out var resultValue) ? resultValue : valueString
                });
            }

            return result;
        }
    }
}
