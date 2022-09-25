using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Relationships
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalConditionTypes", "RelationshipCondition")]
    public class RelationshipSituationGoalCondition : RelationshipCondition
    {
        protected override string GetVariantTunableName(string contextTag = null) => "relationships";
    }
}