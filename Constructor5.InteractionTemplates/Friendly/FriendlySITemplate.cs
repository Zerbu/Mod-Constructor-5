using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using System;

namespace Constructor5.InteractionTemplates.Friendly
{
    [SelectableObjectType("SocialInteractionTemplates", "FriendlyInteraction")]
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

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15507, "Friendly");
        public string TuningActionsFile { get; set; } = "Friendly";

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163702, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24508, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);

            RunTuningActions(context, TuningActionsFile);
        }

        protected override void OnSaveUpgrade(int oldVersion, int newVersion)
        {
            if (PieMenuCategory.GameReference == 15504)
            {
                PieMenuCategory.GameReference = 15507;
            }
        }
    }
}