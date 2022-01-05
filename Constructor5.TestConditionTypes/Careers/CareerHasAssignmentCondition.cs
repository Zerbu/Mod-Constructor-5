using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Currently Has Semi-Active Assignment")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Currently Has Semi-Active Assignment")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Currently Has Semi-Active Assignment")]
    [XmlSerializerExtraType]
    public class CareerHasAssignmentCondition : CareerConditionBase
    {
        public CareerHasAssignmentCondition() => GeneratedLabel = "Careers: Currently Has Semi-Active Assignment";

        [AutoTuneBasic("career")]
        public Reference Career { get; set; } = new Reference();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "has_available_assignment");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
