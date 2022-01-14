using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Interactions
{
    [SelectableObjectType("ObjectiveConditionTypes", "Interaction Time Elapsed Condition", Description = "Checks the total amount of time a Sim has spent performing interactions with a tag. Because of how the game is programmed, this can only be used with tags, not individual interactions.")]
    [XmlSerializerExtraType]
    public class InteractionTimeElapsedCondition : TestCondition
    {
        public InteractionTimeElapsedCondition() => GeneratedLabel = "Interaction Time Elapsed Condition";

        [AutoTuneBasic("length_of_time")]
        public int SimMinutes { get; set; }

        [AutoTuneEnum("tag_to_test")]
        public string Tag { get; set; }

        protected override string GetVariantTunableName() => "total_interaction_time_elapsed_by_tag";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("total_interaction_time_elapsed_by_tag");
            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}