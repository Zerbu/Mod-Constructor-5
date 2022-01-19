using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "CareersCareerLevelResource")]
    [SelectableObjectType("SituationGoalConditionTypes", "CareersCareerLevelResource")]
    [SelectableObjectType("ObjectiveConditionTypes", "CareersCareerLevelResource")]
    [XmlSerializerExtraType]
    public class CareerLevelResourceCondition : CareerConditionBase
    {
        public CareerLevelResourceCondition() => GeneratedLabel = "Careers: Career Level Resource";

        [AutoTuneBasic("career_level")]
        public Reference CareerLevel { get; set; } = new Reference();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "career_level");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
