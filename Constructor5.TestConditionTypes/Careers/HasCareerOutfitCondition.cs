using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Careers
{
    [SelectableObjectType("TestConditionTypes", "CareersHasCareerOutfit")]
    [SelectableObjectType("SituationGoalConditionTypes", "CareersHasCareerOutfit")]
    [SelectableObjectType("ObjectiveConditionTypes", "CareersHasCareerOutfit")]
    [XmlSerializerExtraType]
    public class HasCareerOutfitCondition : CareerConditionBase
    {
        public HasCareerOutfitCondition() => GeneratedLabel = "Careers: Has Career Outfit";

        protected override void OnExportCareer(TunableTuple tupleTunable)
        {
            var testTypeTunable = tupleTunable.GetVariant<TunableTuple>("test_type", "has_career_outfit");
            AutoTunerInvoker.Invoke(this, testTypeTunable);
        }
    }
}
