using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards
{
    [SelectableObjectType("RewardTypes", "NoReward")]
    [SelectableObjectType("RandomRewardTypes", "NoReward")]
    [XmlSerializerExtraType]
    public class EmptyReward : Reward
    {
        public EmptyReward() => GeneratedLabel = "No Reward";

        protected internal override string GetVariantName() => null;

        protected internal override void OnExport(RewardExportContext context)
        {
        }
    }
}
