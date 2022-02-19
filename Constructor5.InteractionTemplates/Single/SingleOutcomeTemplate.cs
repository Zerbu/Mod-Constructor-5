using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.InteractionTemplates.Single
{
    // [SelectableObjectType("SocialInteractionTemplates", "Single Outcome")]
    [SelectableObjectType("MixerInteractionTemplates", "SingleOutcome")]
    [XmlSerializerExtraType]
    public class SingleOutcomeTemplate : InteractionTemplate
    {
        public bool HasAnimation { get; set; }
        public Reference Animation { get; set; } = new Reference();
        public bool IsGlobalInteraction { get; set; }
        public override string Label => "Single Outcome";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        //public Reference BalloonSet { get; set; } = new Reference();

        [AutoTuneBasic("_category")]
        public Reference PieMenuCategory { get; set; } = new Reference();

        public string TuningActionsFile { get; set; } = "SingleOutcome";

        protected override void OnExport(InteractionExportContext context)
        {
            /*PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163702, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24508, ((TuningHeader)context.Tuning).InstanceKey);
            }*/

            AutoTunerInvoker.Invoke(this, context.Tuning);
            RunTuningActions(context, TuningActionsFile);
        }
    }
}