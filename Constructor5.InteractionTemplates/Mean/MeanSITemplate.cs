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

        [AutoTuneBasic("_category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15509, "Mean");

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163706, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24511, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            var tuningContext = new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this
            };
            tuningContext.Variables.Add("LearnTraitLootKey", context.LearnTraitLootKey?.ToString());
            TuningActionInvoker.InvokeFromFile("Mean Social Interaction Template", tuningContext);
        }
    }
}