using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Statistics
{
    [SelectableObjectType("TestConditionTypes", "SkillCondition")]
    [XmlSerializerExtraType]
    public class SkillCondition : TestCondition
    {
        public SkillCondition() => GeneratedLabel = "Skill Condition";

        [AutoTuneVariantRange("skill_range", "interval", "skill_interval")]
        public IntBounds Bounds { get; set; } = new IntBounds();

        [AutoTuneBasic("skill")]
        public Reference Skill { get; set; } = new Reference();

        protected override string GetVariantTunableName(string contextTag = null) => "skill_test";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            AutoTunerInvoker.Invoke(this, variantTunable.Get<TunableTuple>("skill_test"));
        }
    }
}
