using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Core;

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
        public Reference PieMenuCategory { get; set; } = new Reference(8990, "Mischief");

        public string TuningActionsFile { get; set; } = "Mischief";

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
