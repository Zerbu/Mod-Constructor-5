using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "Careers: Career and/or Level Condition")]
    [SelectableObjectType("SituationGoalConditionTypes", "Careers: Career and/or Level Condition")]
    [SelectableObjectType("ObjectiveConditionTypes", "Careers: Career and/or Level Condition")]
    [XmlSerializerExtraType]
    public class CareerCondition : CareerConditionBase
    {
        public CareerCondition() => GeneratedLabel = "Careers: Career and/or Level Condition";

        [AutoTuneVariantRange("user_level")]
        public IntBounds CareerLevel { get; set; } = new IntBounds();

        [AutoTuneIfTrue("allow_invisible_careers")]
        public bool IncludeInvisibleCareers { get; set; }

        public Reference SpecificCareer { get; set; } = new Reference();

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "career_reference");

            AutoTunerInvoker.Invoke(this, testTypeTunable);

            if (ElementTuning.GetSingleInstanceKey(SpecificCareer) != null)
            {
                var tunableVariant1 = testTypeTunable.Set<TunableVariant>("career", "specific_career");
                tunableVariant1.Set<TunableBasic>("specific_career", SpecificCareer);
            }
        }
    }
}