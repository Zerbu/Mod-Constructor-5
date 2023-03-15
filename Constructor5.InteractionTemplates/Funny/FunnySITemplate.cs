using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;

namespace Constructor5.InteractionTemplates.Funny
{
    [SelectableObjectType("SocialInteractionTemplates", "FunnyInteraction")]
    [XmlSerializerExtraType]
    public class FunnySITemplate : InteractionTemplate
    {
        public Reference AnimationOnFailure { get; set; } = new Reference(11844, "Tell Joke Failure");
        public Reference AnimationOnSuccess { get; set; } = new Reference(11845, "Tell Joke Success");
        public Reference BalloonSet { get; set; } = new Reference();
        public bool IsGlobalInteraction { get; set; }
        public bool IsJoke { get; set; }
        public override string Label => "Funny Interaction";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        public int MinimumScoreForAvailability { get; set; }

        [AutoTuneBasic("category")]
        public override Reference PieMenuCategory { get; set; } = new Reference(308253, "Jokes");

        public Reference ScoreType { get; set; } = new Reference() { GameReferenceLabel = "Funny", GameReference = 24570 };
        public Reference ScoreTypeAvailability { get; set; } = new Reference() { GameReferenceLabel = "Funny", GameReference = 24571 };

        public string TuningActionsFile { get; set; } = "Funny";

        public override ulong GetCustomScoreTypeKey(InteractionExportContext context) => (ulong)ElementTuning.GetSingleInstanceKey(ScoreType);

        public override ulong GetFallbackScoreType(SocialInteractionExportContext socialContext)
        {
            Exporter.Current.AddError(socialContext.Element, "InteractionAutoScoreTypeError");
            return 24570;
        }

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163704, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24509, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}