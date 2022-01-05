using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [SelectableObjectType("BroadcasterEffects", "Add Buff to Receiver")]
    [XmlSerializerExtraType]
    public class BroadcasterBuffEffect : BroadcasterEffect
    {
        public BroadcasterBuffEffect() => GeneratedLabel = "Add Buff to Receiver";

        [AutoTuneBuffWithReasonTuple("buff")]
        public BuffWithReason Buff { get; set; } = new BuffWithReason();

        protected internal override void OnExport(BroadcasterExportContext originalContext)
        {
            var tunableVariant1 = originalContext.EffectListTunable.Set<TunableVariant>(null, "buff");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("buff");

            AutoTunerInvoker.Invoke(this, tunableTuple1);

            TestConditionTuning.TuneTestList(tunableTuple1, originalContext.TestConditions, "tests");

        }
    }
}
