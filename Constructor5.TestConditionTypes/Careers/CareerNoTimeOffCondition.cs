using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Has Career with No Time Off")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Has Career with No Time Off")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Has Career with No Time Off")]
    [XmlSerializerExtraType]
    public class CareerNoTimeOffCondition : CareerConditionBase
    {
        public CareerNoTimeOffCondition() => GeneratedLabel = "Careers: Has Career with No Time Off";

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "time_off");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
