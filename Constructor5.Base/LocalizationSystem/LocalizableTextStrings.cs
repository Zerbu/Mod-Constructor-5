using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Constructor5.Base.LocalizationSystem
{
    public class LocalizableTextStrings
    {
        [XmlElement("String")]
        public List<LocalizableTextStringValue> Strings { get; set; } = new List<LocalizableTextStringValue>();
    }
}
