using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Xml;

namespace Constructor5.InteractionTemplates.Romance
{
    [SelectableObjectType("SocialInteractionTemplates", "Romance Interaction")]
    [XmlSerializerExtraType]
    public class RomanceSITemplate : InteractionTemplate
    {
        public override string Label => "Romance Interaction";

        public bool IsGlobalInteraction { get; set; }

        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        public Reference BalloonSet { get; set; } = new Reference();

        public Reference AnimationOnSuccess { get; set; } = new Reference(12004, "Flirty Compliment Success");
        public Reference AnimationOnFailure { get; set; } = new Reference(12003, "Flirty Compliment Failure");

        [AutoTuneBasic("_category")]
        public Reference PieMenuCategory { get; set; } = new Reference(15510, "Romance");

        protected override void OnExport(InteractionExportContext context)
        {
            PythonBuilder.AddStep(SnippetInteractionsPythonStep.Current);
            SnippetInteractionsPythonStep.Current.AddSnippetInteraction(163713, ((TuningHeader)context.Tuning).InstanceKey);
            if (IsGlobalInteraction)
            {
                SnippetInteractionsPythonStep.Current.AddSnippetInteraction(24510, ((TuningHeader)context.Tuning).InstanceKey);
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
            var tuningContext = new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this
            };
            tuningContext.Variables.Add("LearnTraitLootKey", context.LearnTraitLootKey?.ToString());
            TuningActionInvoker.InvokeFromFile("Romance Social Interaction Template", tuningContext);
        }
    }
}
