using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Buffs
{
    [SelectableObjectType("ObjectiveConditionTypes", "BuffAddedCondition")]
    [XmlSerializerExtraType]
    public class BuffAddedCondition : TestCondition
    {
        public BuffAddedCondition() => GeneratedLabel = "Buff Added Condition";

        [AutoTuneReferenceList("acceptable_buffs")]
        public ReferenceList Buffs { get; set; } = new ReferenceList();

        protected override string GetVariantTunableName() => "buff_added";

        protected override void OnExportVariant(TunableBase variantTunable)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("buff_added"));
    }
}
