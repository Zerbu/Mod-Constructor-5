using System.Xml.Serialization;

namespace Constructor5.Base.ExportSystem.Tuning
{
    public class TunableVariant : TunableBase
    {
        [XmlAttribute("t")]
        public string Variant { get; set; }
    }
}