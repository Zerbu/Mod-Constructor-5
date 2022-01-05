using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Xml;

namespace Constructor5.InteractionTemplates.Funny
{
    [SelectableObjectType("SocialInteractionTemplates", "Funny Interaction")]
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

        [AutoTuneBasic("_category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15508, "Funny");

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163704, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24509, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            var tuningContext = new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this
            };
            tuningContext.Variables.Add("LearnTraitLootKey", context.LearnTraitLootKey?.ToString());
            TuningActionInvoker.InvokeFromFile("Funny Social Interaction Template", tuningContext);
        }
    }
}