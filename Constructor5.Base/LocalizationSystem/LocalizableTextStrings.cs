using System.Collections.Generic;
using System.Xml.Serialization;

namespace Constructor5.Base.LocalizationSystem
{
    public class LocalizableTextStrings
    {
        [XmlElement("String")]
        public List<LocalizableTextStringValue> Strings { get; set; } = new List<LocalizableTextStringValue>();
    }
}
