using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Situations
{
    [SelectableObjectType("SituationGoalConditionTypes", "SituationCondition")]
    [XmlSerializerExtraType]
    public class SituationConditionForGoals : SituationCondition
    {
        protected override string GetVariantTunableName(string contextTag = null) => "situation_running";
    }
}