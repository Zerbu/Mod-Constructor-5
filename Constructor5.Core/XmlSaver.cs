using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Constructor5.Core
{
    public static class XmlSaver
    {
        public static void SaveFile(object obj, string fileName)
        {
            AutoCreateDirectory(fileName);

            // save to a memory stream first to prevent the file from becoming corrupted if there is an error
            var memoryStream = new MemoryStream();
            SaveStream(obj, memoryStream);

            using (var fileStream = File.Open(fileName, FileMode.OpenOrCreate))
            {
                fileStream.SetLength(0);
                memoryStream.WriteTo(fileStream);
            }
        }

        public static void SaveStream(object obj, Stream stream) => GetSerializer(obj.GetType()).Serialize(stream, obj);

        private static Dictionary<Type, XmlSerializer> Serializers { get; } = new Dictionary<Type, XmlSerializer>();

        private static void AutoCreateDirectory(string fileName)
        {
            var dir = Path.GetDirectoryName(fileName);
            if (!string.IsNullOrEmpty(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private static XmlSerializer CreateSerializer(Type type)
        {
            var extraTypes = new List<Type>();
            foreach (var typeToAdd in Reflection.GetTypesWithAttribute<XmlSerializerExtraTypeAttribute>(true))
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