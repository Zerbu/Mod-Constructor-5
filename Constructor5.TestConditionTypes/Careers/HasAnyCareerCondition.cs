using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Has Any Career")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Has Any Career")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Has Any Career")]
    [XmlSerializerExtraType]
    public class HasAnyCareerCondition : CareerConditionBase
    {
        public HasAnyCareerCondition() => GeneratedLabel = "Careers: Has Any Career";

        [AutoTuneBasic("has_career")]
        public bool HasCareer { get; set; } = true;

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "has_career");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
