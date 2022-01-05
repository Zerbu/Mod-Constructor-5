using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Situations
{
    [SelectableObjectType("SituationGoalConditionTypes", "Situation Condition")]
    [XmlSerializerExtraType]
    public class SituationConditionForGoals : SituationCondition
    {
        protected override string GetVariantTunableName() => "situation_running";
    }
}