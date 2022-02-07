using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "MoneyRewardFixedAmount")]
    [SelectableObjectType("RandomRewardTypes", "MoneyRewardFixedAmount")]
    [XmlSerializerExtraType]
    public class MoneyFixedReward : Reward
    {
        public MoneyFixedReward() => GeneratedLabel = "Money Reward (Fixed Amount)";

        public int Amount { get; set; }

        protected internal override string GetVariantName() => "money";

        protected internal override void OnExport(RewardExportContext context)
        {
            var tunableTuple1 = context.Tunable.Get<TunableTuple>("money");
            var tunableVariant1 = tunableTuple1.Set<TunableVariant>("money", "literal");
            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("literal");
            tunableTuple2.Set<TunableBasic>("value", Amount);
        }
    }
}
