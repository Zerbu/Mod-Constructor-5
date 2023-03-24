using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Constructor5.Core
{
    public static class XmlLoader
    {
        public static object LoadFile(Type type, string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            using (var stream = File.OpenRead(fileName))
            {
                var result = LoadStream(type, stream);
                return result;
            }
        }

        public static T LoadFile<T>(string fileName) => (T)LoadFile(typeof(T), fileName);

        public static object LoadStream(Type type, Stream stream) => GetSerializer(type).Deserialize(stream);

        private static Dictionary<Type, XmlSerializer> Serializers { get; } = new Dictionary<Type, XmlSerializer>();

        private static XmlSerializer CreateSerializer(Type type)
        {
            var extraTypes = new List<Type>();
            foreach (var typeToAdd in Reflection.GetTypesWithAttribute<XmlSerializerExtraTypeAttribute>(false))
            {
                extraTypes.Add(typeToAdd);
            }

            var result = new XmlSerializer(type, extraTypes.ToArray());
            Serializers.Add(type, result);
            return result;
        }

        private static XmlSerializer GetSerializer(Type type) => Serializers.ContainsKey(type) ? Serializers[type] : CreateSerializer(type);
    }
}