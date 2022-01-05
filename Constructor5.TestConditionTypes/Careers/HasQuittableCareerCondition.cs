using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Has Quittable Career")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Has Quittable Career")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Has Quittable Career")]
    [XmlSerializerExtraType]
    public class HasQuittableCareerCondition : CareerConditionBase
    {
        public HasQuittableCareerCondition() => GeneratedLabel = "Careers: Has Quittable Career";

        [AutoTuneBasic("has_quittable_career")]
        public bool HasCareer { get; set; } = true;

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "has_quittable_career");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
