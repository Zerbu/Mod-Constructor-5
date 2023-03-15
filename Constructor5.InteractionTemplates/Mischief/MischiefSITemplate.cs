using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Core;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.InteractionTemplates.Mischief
{
    [SelectableObjectType("SocialInteractionTemplates", "MischiefInteraction")]
    [XmlSerializerExtraType]
    public class MischiefSITemplate : InteractionTemplate
    {
        public override string Label => "Mischief Interaction";

        public bool IsGlobalInteraction { get; set; }

        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        public Reference AnimationOnSuccess { get; set; } = new Reference(11955, "Scary Story Success");
        public Reference AnimationOnFailure { get; set; } = new Reference(11953, "Scary Story Failure");

        public Reference BalloonSet { get; set; } = new Reference();

        [AutoTuneBasic("category")]
        public override Reference PieMenuCategory { get; set; } = new Reference(314804, "Pranks");

        public Reference ScoreType { get; set; } = new Reference() { GameReferenceLabel = "Mischief", GameReference = 24574 };
        public Reference ScoreTypeAvailability { get; set; } = new Reference() { GameReferenceLabel = "Mischief", GameReference = 24574 };

        public string TuningActionsFile { get; set; } = "Mischief";

        public override ulong GetCustomScoreTypeKey(InteractionExportContext context) => (ulong)ElementTuning.GetSingleInstanceKey(ScoreType);

        public override ulong GetFallbackScoreType(SocialInteractionExportContext socialContext)
        {
            Exporter.Current.AddError(socialContext.Element, "InteractionAutoScoreTypeError");
            return 24574;
        }

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163708, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24512, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}
