using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "Money Reward (Random In Range)")]
    [SelectableObjectType("RandomRewardTypes", "Money Reward (Random In Range)")]
    [XmlSerializerExtraType]
    public class MoneyRandomAmount : Reward
    {
        public MoneyRandomAmount() => GeneratedLabel = "Money Reward (Random In Range)";

        public int LowerBound { get; set; }
        public int UpperBound { get; set; }

        protected internal override string GetVariantName() => "money";

        protected internal override void OnExport(RewardExportContext context)
        {
            var tunableTuple1 = context.Tunable.Get<TunableTuple>("money");
            var tunableVariant1 = tunableTuple1.Set<TunableVariant>("money", "random_in_range");
            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("random_in_range");
            tunableTuple2.Set<TunableBasic>("lower_bound", LowerBound);
            tunableTuple2.Set<TunableBasic>("upper_bound", UpperBound);
        }
    }
}
