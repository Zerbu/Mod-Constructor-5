using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "Satisfaction Points Reward")]
    [SelectableObjectType("RandomRewardTypes", "Satisfaction Points Reward")]
    [XmlSerializerExtraType]
    public class SatisfactionPointsReward : Reward
    {
        public SatisfactionPointsReward() => GeneratedLabel = "Satisfaction Points Reward";

        public int Amount { get; set; }

        protected internal override string GetVariantName() => "whim_bucks";

        protected internal override void OnExport(RewardExportContext context)
        {
            var tunableTuple1 = context.Tunable.Get<TunableTuple>("whim_bucks");
            tunableTuple1.Set<TunableBasic>("whim_bucks", Amount);
        }
    }
}
