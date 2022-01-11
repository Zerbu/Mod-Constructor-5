using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.TestConditionTypes.Collections;

namespace Constructor5.TestConditionTypes.Perks
{
    [SelectableObjectType("ObjectiveConditionTypes", "Club Condition")]
    [XmlSerializerExtraType]
    public class ClubObjectiveCondition : CollectionCondition
    {
        protected override string GetVariantTunableName() => "club_tests";
    }
}