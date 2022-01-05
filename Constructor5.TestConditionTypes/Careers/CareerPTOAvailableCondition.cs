using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: PTO Available")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: PTO Available")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: PTO Available")]
    [XmlSerializerExtraType]
    public class CareerPTOAvailableCondition : CareerConditionBase
    {
        public CareerPTOAvailableCondition() => GeneratedLabel = "Careers: PTO Available";

        [AutoTuneBasic("career")]
        public Reference Career { get; set; } = new Reference();

        [AutoTuneThresholdTuple("required_pto_available")]
        public Threshold RequiredPtoAvailable { get; set; } = new Threshold();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "pto_amount");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
