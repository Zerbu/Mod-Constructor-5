using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Statistics
{
    [SelectableObjectType("TestConditionTypes", "SkillTagCondition")]
    [SelectableObjectType("SituationGoalConditionTypes", "SkillTagCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "SkillTagCondition")]
    [XmlSerializerExtraType]
    public class SkillTagCondition : TestCondition
    {
        public SkillTagCondition() => GeneratedLabel = "Skill Tag Condition";

        [AutoTuneEnum("who")]
        public string Participant { get; set; }

        [AutoTuneBasic("skill_quantity", IgnoreIf = "1")]
        public int Quantity { get; set; }

        [AutoTuneEnum("skill_tag")]
        public string SkillTag { get; set; }

        [AutoTuneThresholdTuple("skill_threshold")]
        public Threshold Threshold { get; set; } = new Threshold(1);

        protected override string GetVariantTunableName(string contextTag = null) => "skill_tag";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("skill_tag");
            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}
