using System;
using System.Collections.Generic;

namespace Constructor5.UI.Dialogs.ObjectTypeSelector
{
    public static class ObjectTypeExtraTabManager
    {
        public static void AddTab(string registryCategory, Type type)
        {
            var typeDictionary = ExtraTabs.ContainsKey(registryCategory) ? ExtraTabs[registryCategory] : null;
            if (typeDictionary == null)
            {
                typeDictionary = new List<Type>();
                ExtraTabs.Add(registryCategory, typeDictionary);
            }
            typeDictionary.Add(type);
        }

        public static Type[] GetExtraTabs(string registryCategory)
        {
            var typeDictionary = ExtraTabs.ContainsKey(registryCategory) ? ExtraTabs[registryCategory] : null;
            if (typeDictionary == null)
            {
                return new Type[0];
            }

            return typeDictionary.ToArray();
        }

        private static Dictionary<string, List<Type>> ExtraTabs { get; } = new Dictionary<string, List<Type>>();
    }
}