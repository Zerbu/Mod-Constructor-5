using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Buffs.References;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "BuffReward")]
    [SelectableObjectType("RandomRewardTypes", "BuffReward")]
    [XmlSerializerExtraType]
    public class BuffReward : Reward
    {
        public BuffReward() => GeneratedLabel = "Buff Reward";

        [AutoTuneBuffWithReasonTuple("buff")]
        public BuffWithReason Buff { get; set; } = new BuffWithReason();

        protected internal override string GetVariantName() => "buff";

        protected internal override void OnExport(RewardExportContext context)
            => AutoTunerInvoker.Invoke(this, context.Tunable.Get<TunableTuple>("buff"));
    }
}
