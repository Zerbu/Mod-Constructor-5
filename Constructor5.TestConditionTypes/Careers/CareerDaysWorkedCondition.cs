using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Days Worked")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Days Worked")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Days Worked")]
    [XmlSerializerExtraType]
    public class CareerDaysWorkedCondition : CareerConditionBase
    {
        public CareerDaysWorkedCondition() => GeneratedLabel = "Careers: Days Worked";

        [AutoTuneBasic("active_only")]
        public bool ActiveOnly { get; set; }

        [AutoTuneBasic("career")]
        public Reference Career { get; set; } = new Reference();

        [AutoTuneThresholdTuple("threshold")]
        public Threshold Threshold { get; set; } = new Threshold();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "days_worked");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}