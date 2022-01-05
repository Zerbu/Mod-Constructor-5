using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Statistics
{
    [SelectableObjectType("TestConditionTypes", "Skill In Use Condition")]
    /*[SelectableObjectType("SituationGoalConditionTypes", "Skill Tag Condition")]
    [SelectableObjectType("ObjectiveConditionTypes", "Skill Tag Condition")]*/
    [XmlSerializerExtraType]
    public class SkillInUseCondition : TestCondition
    {
        [AutoTuneEnum("who")]
        public string Participant { get; set; }

        public Reference Skill { get; set; } = new Reference();

        protected override string GetVariantTunableName() => "skill_in_use";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tunableTuple1 = variantTunable.Get<TunableTuple>("skill_in_use");
            var tunableVariant1 = tunableTuple1.Set<TunableVariant>("skill", "Specified_Skill");
            tunableVariant1.Set<TunableBasic>("Specified_Skill", Skill);

            AutoTunerInvoker.Invoke(this, tunableTuple1);
        }
    }
}