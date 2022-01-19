using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "Perk Points Reward")]
    [SelectableObjectType("RandomRewardTypes", "Perk Points Reward")]
    [XmlSerializerExtraType]
    public class PerkPointsReward : Reward
    {
        public PerkPointsReward() => GeneratedLabel = "Perk Points Reward";

        public int Amount { get; set; } = 10;
        public string PerkType { get; set; }

        protected internal override string GetVariantName() => "bucks";

        protected internal override void OnExport(RewardExportContext context)
        {
            var tunableTuple1 = context.Tunable.Get<TunableTuple>("bucks");
            tunableTuple1.Set<TunableBasic>("amount", Amount);
            tunableTuple1.Set<TunableEnum>("bucks_type", PerkType);
        }
    }
}