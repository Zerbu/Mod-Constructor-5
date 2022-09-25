using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("ObjectiveConditionTypes", "PerksHasSpecificPerkCondition")]
    [XmlSerializerExtraType]
    public class HasSpecificPerkCondition : TestCondition
    {
        public HasSpecificPerkCondition() => GeneratedLabel = "Has Specific Perk Condition";

        [AutoTuneIfTrue("invert")]
        public bool Inverted { get; set; }

        [AutoTuneEnum("participant")]
        public string Participant { get; set; }

        [AutoTuneBasic("bucks_perk")]
        public Reference Perk { get; set; } = new Reference();

        protected override string GetVariantTunableName(string contextTag = null) => "bucks_perk_unlocked";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tuple = variantTunable.Get<TunableTuple>("bucks_perk_unlocked");
            AutoTunerInvoker.Invoke(this, tuple);
        }
    }
}