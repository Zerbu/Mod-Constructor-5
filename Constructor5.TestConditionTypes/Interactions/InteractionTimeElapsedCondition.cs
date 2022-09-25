using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;

namespace Constructor5.TestConditionTypes.Interactions
{
    [SelectableObjectType("ObjectiveConditionTypes", "InteractionTimeElapsedCondition", Description = "InteractionTimeElapsedConditionNotice")]
    [XmlSerializerExtraType]
    public class InteractionTimeElapsedCondition : TestCondition
    {
        public InteractionTimeElapsedCondition() => GeneratedLabel = "Interaction Time Elapsed Condition";

        [AutoTuneBasic("length_of_time")]
        public int SimMinutes { get; set; }

        [AutoTuneEnum("tag_to_test")]
        public string Tag { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "total_interaction_time_elapsed_by_tag";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("total_interaction_time_elapsed_by_tag");
            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}