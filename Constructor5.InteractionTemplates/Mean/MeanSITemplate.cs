using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.InteractionTemplates.Mean
{
    [SelectableObjectType("SocialInteractionTemplates", "MeanInteraction")]
    [XmlSerializerExtraType]
    public class MeanSITemplate : InteractionTemplate
    {
        public Reference AnimationOnFailure { get; set; } = new Reference(11947, "Insult Success");
        public Reference AnimationOnSuccess { get; set; } = new Reference(11939, "Insult Failure");
        public Reference BalloonSet { get; set; } = new Reference();
        public bool IsGlobalInteraction { get; set; }
        public override string Label => "Mean Interaction";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();
        public int MinimumScoreForAvailability { get; set; }

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15509, "Mean");

        public Reference ScoreType { get; set; } = new Reference() { GameReferenceLabel = "Mean", GameReference = 24572 };
        public Reference ScoreTypeAvailability { get; set; } = new Reference() { GameReferenceLabel = "Mean", GameReference = 24573 };

        public string TuningActionsFile { get; set; } = "Mean";

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163706, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24511, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}