using System.Xml.Serialization;

namespace Constructor5.Base.LocalizationSystem
{
    public class LocalizableTextStringValue
    {
        [XmlAttribute]
        public string Key { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
