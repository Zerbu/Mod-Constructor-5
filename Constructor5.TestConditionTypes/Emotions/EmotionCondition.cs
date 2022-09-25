using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Emotions
{
    [SelectableObjectType("TestConditionTypes", "EmotionCondition")]
    [SelectableObjectType("SituationGoalConditionTypes", "EmotionCondition")]
    [XmlSerializerExtraType]
    public class EmotionCondition : TestCondition
    {
        public EmotionCondition() => GeneratedLabel = "Emotion Condition";

        [AutoTuneBasic("mood")]
        public Reference Emotion { get; set; } = new Reference();

        [AutoTuneIfTrue("disallow")]
        public bool Inverted { get; set; }

        [AutoTuneEnum("who")]
        public string Participant { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "mood";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());
            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}