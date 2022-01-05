using System.Collections.Generic;
using System.Xml.Serialization;

namespace Constructor5.Base.ElementSystem
{
    [XmlRoot("PresetGroup")]
    public class PresetGroup
    {
        [XmlIgnore]
        public bool IsCustom { get; set; }

        [XmlAttribute]
        public string Label { get; set; }

        public string Notice { get; set; }

        [XmlElement("Preset")]
        public List<Preset> Presets { get; } = new List<Preset>();
    }
}
