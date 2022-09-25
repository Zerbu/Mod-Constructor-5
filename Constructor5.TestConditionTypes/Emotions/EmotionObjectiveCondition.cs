using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Emotions
{
    [SelectableObjectType("ObjectiveConditionTypes", "EmotionCondition")]
    [XmlSerializerExtraType]
    public class EmotionObjectiveCondition : EmotionCondition
    {
        protected override string GetVariantTunableName(string contextTag = null) => "mood_test";
    }
}