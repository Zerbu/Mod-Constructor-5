using System;
using System.Collections.Generic;

namespace Constructor5.Core
{
    public static class ContentRegistry
    {
        public static T Get<T>(string category, string id)
        {
            var dictionary = GetDictionary(category);

            if (!dictionary.ContainsKey(id))
            {
                return default;
            }

            return (T)dictionary[id];
        }

        public static T[] GetAll<T>(string category)
        {
            var dictionary = GetDictionary(category);

            var result = new List<T>();

            foreach (var value in dictionary.Values)
            {
                result.Add((T)value);
            }

            return result.ToArray();
        }

        public static void Initialize()
        {
            foreach (var onLoad in Reflection.GetTypesWithAttribute<AutoRegisterSubtypesAttribute>(true))
            {
                RegisterSubtypesOf(onLoad.Name, onLoad);
            }
        }

        public static void Register(string category, string key, object obj)
        {
            var dictionary = GetDictionary(category);
            if (dictionary.ContainsKey(key))
            {
                throw new Exception($"The key is already assigned to content: {dictionary[key]}");
            }
            dictionary.Add(key, obj);
        }

        public static void Unregister(string category, string key) => GetDictionary(category).Remove(key);

        private static Dictionary<string, Dictionary<string, object>> Dictionaries { get; } = new Dictionary<string, Dictionary<string, object>>();

        private static Dictionary<string, object> GetDictionary(string category)
        {
            if (!Dictionaries.ContainsKey(category))
            {
                Dictionaries.Add(category, new Dictionary<string, object>());
            }

            return Dictionaries[category];
        }

        private static void RegisterSubtypesOf(string category, Type type)
        {
            foreach (var contentType in Reflection.GetSubtypes(type))
            {
                Register(category, contentType.Name, Reflection.CreateObject(contentType));
            }
        }
    }
}