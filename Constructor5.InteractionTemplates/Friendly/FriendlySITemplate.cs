using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.InteractionTemplates.Friendly
{
    [SelectableObjectType("SocialInteractionTemplates", "Friendly Interaction")]
    [XmlSerializerExtraType]
    public class FriendlySITemplate : InteractionTemplate
    {
        public Reference AnimationOnFailure { get; set; } = new Reference(11853, "Ask Question Failure");
        public Reference AnimationOnFailureTarget { get; set; } = new Reference(11878, "Annoyed");
        public Reference AnimationOnSuccess { get; set; } = new Reference(11854, "Ask Question Success");
        public Reference AnimationOnSuccessTarget { get; set; } = new Reference(11881, "Positive");
        public Reference BalloonSet { get; set; } = new Reference();
        public bool IsGlobalInteraction { get; set; }
        public override string Label => "Friendly Interaction";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();
        public int MinimumScoreForAvailability { get; set; }

        [AutoTuneBasic("_category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15504, "Friendly");

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163702, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24508, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            var tuningContext = new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this
            };
            tuningContext.Variables.Add("LearnTraitLootKey", context.LearnTraitLootKey?.ToString());
            TuningActionInvoker.InvokeFromFile("Friendly Social Interaction Template", tuningContext);
        }
    }
}