using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("ObjectiveConditionTypes", "Perk Amount Condition")]
    [SelectableObjectType("TestConditionTypes", "Perk Amount Condition")]
    [XmlSerializerExtraType]
    public class PerkAmountCondition : TestCondition
    {
        public PerkAmountCondition() => GeneratedLabel = "Perk Amount Condition";

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        [AutoTuneBasic("bucks_type")]
        public string PerkType { get; set; }

        [AutoTuneThresholdTuple("value_threshold")]
        public Threshold Threshold { get; set; } = new Threshold();

        protected override string GetVariantTunableName() => "bucks_test";

        protected override void OnExportVariant(TunableBase variantTunable)
            => AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("bucks_test"));
    }
}