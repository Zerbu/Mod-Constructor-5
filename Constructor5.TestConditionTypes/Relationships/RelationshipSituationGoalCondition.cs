using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Relationships
{
    [XmlSerializerExtraType]
    [SelectableObjectType("SituationGoalConditionTypes", "Relationship Condition")]
    public class RelationshipSituationGoalCondition : RelationshipCondition
    {
        protected override string GetVariantTunableName() => "relationship";
    }
}