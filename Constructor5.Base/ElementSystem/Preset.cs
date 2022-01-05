using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Constructor5.Base.ElementSystem
{
    [XmlRoot("Preset")]
    public class Preset
    {
        public string FullValue => Label != null ? $"{Value} ({Label})" : Value;

        [XmlAttribute]
        public string Label { get; set; }

        [XmlAttribute("Notice")]
        public string Notice { get; set; }

        [XmlAttribute("Tags")]
        public string TagsString { get; set; }

        [XmlAttribute]
        public string Value { get; set; }

        [XmlIgnore]
        public Element CustomElement { get; set; }

        public string[] GetTagsArray() => TagsString?.Split(',');
    }
}
