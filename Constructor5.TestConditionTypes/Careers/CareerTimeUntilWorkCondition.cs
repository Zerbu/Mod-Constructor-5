using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "CareersTimeUntilWork")]
    [SelectableObjectType("SituationGoalConditionTypes", "CareersTimeUntilWork")]
    [SelectableObjectType("ObjectiveConditionTypes", "CareersTimeUntilWork")]
    [XmlSerializerExtraType]
    public class CareerTimeUntilWorkCondition : CareerConditionBase
    {
        public CareerTimeUntilWorkCondition() => GeneratedLabel = "Careers: Time Until Work";

        [AutoTuneBasic("career")]
        public Reference Career { get; set; } = new Reference();

        [AutoTuneTupleRange("hours_till_work")]
        public IntBounds HoursUntilWork { get; set; } = new IntBounds();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "time_until_work");
            AutoTunerInvoker.Invoke(this, testTypeTunable);

            if (ElementTuning.GetSingleInstanceKey(Career) == null)
            {
                tupleTunable.Set<TunableBasic>("check_all_careers", "True");
            }
        }
    }
}