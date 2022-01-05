using System.Xml.Serialization;

namespace Constructor5.Base.ExportSystem.Tuning
{
    public abstract class TunableBase : TuningBase
    {
        [XmlAttribute("n")]
        public string Name { get; set; }

        [XmlAttribute("p")]
        public string Param { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
