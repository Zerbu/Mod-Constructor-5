using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.TestConditionTypes.Collections;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("ObjectiveConditionTypes", "PerksClubStatusCondition")]
    [XmlSerializerExtraType]
    public class ClubObjectiveCondition : ClubCondition
    {
        protected override string GetVariantTunableName() => "club_tests";
    }
}