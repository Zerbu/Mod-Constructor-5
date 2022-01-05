using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Interactions
{
    [SelectableObjectType("TestConditionTypes", "Interaction Running Condition")]
    [XmlSerializerExtraType]
    public class InteractionRunningCondition : TestCondition
    {
        public InteractionRunningCondition() => GeneratedLabel = "Interaction Running Condition";

        [AutoTuneEnum("participant")]
        public string Participant { get; set; }

        [AutoTuneReferenceList("affordances")]
        public ReferenceList Interactions { get; set; } = new ReferenceList();

        [AutoTuneIfTrue("test_for_not_running")]
        public bool Inverted { get; set; }

        protected override string GetVariantTunableName() => "user_running_interaction";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("user_running_interaction");
            AutoTunerInvoker.Invoke(this, tupleTunable);

            if (string.IsNullOrEmpty(Participant))
            {
                tupleTunable.Set<TunableEnum>("participant", "Actor");
            }
        }
    }
}
