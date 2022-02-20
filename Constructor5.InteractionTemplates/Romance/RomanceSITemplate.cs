using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.InteractionTemplates.Romance
{
    [SelectableObjectType("SocialInteractionTemplates", "RomanceInteraction")]
    [XmlSerializerExtraType]
    public class RomanceSITemplate : InteractionTemplate
    {
        public Reference AnimationOnFailure { get; set; } = new Reference(12003, "Flirty Compliment Failure");
        public Reference AnimationOnSuccess { get; set; } = new Reference(12004, "Flirty Compliment Success");
        public Reference BalloonSet { get; set; } = new Reference();
        public bool IsGlobalInteraction { get; set; }
        public override string Label => "Romance Interaction";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();
        public int MinimumScoreForAvailability { get; set; }

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15510, "Romance");

        public string TuningActionsFile { get; set; } = "Romance";

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163713, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24510, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}