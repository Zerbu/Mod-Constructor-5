using Constructor5.Base.ExportSystem.Tuning.SimData;
using System.Xml.Serialization;

namespace Constructor5.Base.ExportSystem.Tuning
{
    [XmlRoot("I")]
    public class TuningHeader : TuningBase
    {
        [XmlAttribute("c")]
        public string Class { get; set; }

        [XmlAttribute("s")]
        public ulong InstanceKey { get; set; }

        [XmlAttribute("i")]
        public string InstanceType { get; set; }

        [XmlIgnore]
        public string InstanceTypeKeyOverride { get; set; }

        [XmlAttribute("m")]
        public string Module { get; set; }

        [XmlAttribute("n")]
        public string Name { get; set; }

        [XmlIgnore]
        public SimDataHandler SimDataHandler { get; set; }

        [XmlIgnore]
        public SimDataBuilder SimDataBuilder { get; set; }

        public string GetHexGroupKey() => "0";

        public string GetHexInstanceKey() => InstanceKey.ToString("X");

        public string GetHexTypeKey() => InstanceTypeKeyOverride ?? FNVHasher.FNV32(InstanceType, false).ToString("X");
    }
}