using Constructor5.Base.ExportSystem.Tuning;
using System.Xml.Serialization;

namespace Constructor5.Elements.Rewards
{
    public abstract class Reward
    {
        public string GeneratedLabel { get; set; }

        [XmlIgnore]
        public string Label => GeneratedLabel;

        protected internal abstract string GetVariantName();

        protected internal abstract void OnExport(RewardExportContext context);
    }
}