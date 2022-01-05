using Constructor5.Base.SelectableObjects;
using Constructor5.Xml;

namespace Constructor5.TestConditionTypes.Emotions
{
    [SelectableObjectType("ObjectiveConditionTypes", "Emotion Condition")]
    [XmlSerializerExtraType]
    public class EmotionObjectiveCondition : EmotionCondition
    {
        protected override string GetVariantTunableName() => "mood_test";
    }
}