using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.TestConditionTypes.Interactions
{
    [SelectableObjectType("ObjectiveConditionTypes", "InteractionCondition")]
    [XmlSerializerExtraType]
    public class ObjectiveInteractionCondition : TestCondition
    {
        public ObjectiveInteractionCondition() => GeneratedLabel = "Interaction Condition";

        public bool IncludeCancelledInteractions { get; set; }
        public bool IncludeGameCancelledInteractions { get; set; } = true;

        [AutoTuneReferenceList("affordances")]
        public ReferenceList Interactions { get; set; } = new ReferenceList();

        public ObservableCollection<string> InteractionTags { get; } = new ObservableCollection<string>();
        public int MinimumRunningTime { get; set; }
        public bool SuccessfulOnly { get; set; }

        protected override string GetVariantTunableName() => "ran_interaction_test";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("ran_interaction_test");
            AutoTunerInvoker.Invoke(this, tupleTunable);

            foreach (var tag in InteractionTags)
            {
                var tunableList2 = tupleTunable.Get<TunableList>("tags");
                tunableList2.Set<TunableEnum>(null, tag);
            }

            if (MinimumRunningTime > 0)
            {
                tupleTunable.SetVariant<TunableBasic>("running_time", "enabled", MinimumRunningTime.ToString());
            }

            if (SuccessfulOnly)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("interaction_outcome", "enabled");
                tunableVariant1.Set<TunableEnum>("enabled", "SUCCESS");
            }
        }
    }
}