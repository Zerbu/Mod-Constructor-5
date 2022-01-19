using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [SelectableObjectType("BroadcasterEffects", "Add Buff to Sender")]
    [XmlSerializerExtraType]
    public class BroadcasterSelfBuffEffect : BroadcasterEffect
    {
        public BroadcasterSelfBuffEffect() => GeneratedLabel = "Add Buff to Sender";

        [AutoTuneBuffWithReasonTuple("buff")]
        public BuffWithReason Buff { get; set; } = new BuffWithReason();

        [AutoTuneTupleRange("broadcastee_count_interval", UpperDefaultOverride = int.MaxValue)]
        public IntBounds RequiredReceiversRange { get; set; } = new IntBounds(false, false, 1, 1);

        protected internal override void OnExport(BroadcasterExportContext originalContext)
        {
            var tunableVariant1 = originalContext.EffectListTunable.Set<TunableVariant>(null, "self_buff");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("self_buff");

            AutoTunerInvoker.Invoke(this, tunableTuple1);

            TestConditionTuning.TuneTestList(tunableTuple1, originalContext.TestConditions, "tests");

        }
    }
}
