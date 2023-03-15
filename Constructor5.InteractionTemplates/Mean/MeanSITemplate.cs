using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;

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
        public override Reference PieMenuCategory { get; set; } = new Reference(308252, "Malicious");

        public Reference ScoreType { get; set; } = new Reference() { GameReferenceLabel = "Mean", GameReference = 24572 };
        public Reference ScoreTypeAvailability { get; set; } = new Reference() { GameReferenceLabel = "Mean", GameReference = 24573 };

        public string TuningActionsFile { get; set; } = "Mean";

        public override ulong GetCustomScoreTypeKey(InteractionExportContext context) => (ulong)ElementTuning.GetSingleInstanceKey(ScoreType);

        public override ulong GetFallbackScoreType(SocialInteractionExportContext socialContext)
        {
            Exporter.Current.AddError(socialContext.Element, "InteractionAutoScoreTypeError");
            return 24572;
        }

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