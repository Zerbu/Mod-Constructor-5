using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Attended First Day")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Attended First Day")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Attended First Day")]
    [XmlSerializerExtraType]
    public class CareerAttendedFirstDayCondition : CareerConditionBase
    {
        public CareerAttendedFirstDayCondition() => GeneratedLabel = "Careers: Attended First Day";

        [AutoTuneBasic("career")]
        public Reference Career { get; set; } = new Reference();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "attended_first_day");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
