using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "TraitReward")]
    [SelectableObjectType("RandomRewardTypes", "TraitReward")]
    [XmlSerializerExtraType]
    public class TraitReward : Reward
    {
        public TraitReward() => GeneratedLabel = "Trait Reward";

        public Reference Trait { get; set; } = new Reference();

        protected internal override string GetVariantName() => "trait";

        protected internal override void OnExport(RewardExportContext context)
        {
            var tunableTuple1 = context.Tunable.Get<TunableTuple>("trait");
            tunableTuple1.Set<TunableBasic>("trait", Trait);
        }
    }
}
