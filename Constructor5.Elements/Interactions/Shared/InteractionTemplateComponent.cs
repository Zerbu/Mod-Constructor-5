using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social.ContextModifiers;
using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Social
{
    [XmlSerializerExtraType]
    [SocialInteractionComponent]
    [MixerInteractionComponent]
    public class InteractionTemplateComponent : InteractionComponent
    {
        public override int ComponentDisplayOrder => 2;
        public override string ComponentLabel => "Main Content";

        public InteractionTemplate Template { get; set; } = new DefaultInteractionTemplate();

        protected internal override void OnExport(InteractionExportContext context)
        {
            var socialContext = context as SocialInteractionExportContext;

            var traitContextModifier = Element.GetContextModifier<SIAssociatedTrait>();
            if (traitContextModifier != null)
            {
                socialContext.TraitKey = (ulong)ElementTuning.GetSingleInstanceKey(traitContextModifier.Trait);
                socialContext.LearnTraitLootKey = CreateLearnTraitLoot(socialContext);
            }

            Template.OnExport(context);
        }

        private ulong CreateLearnTraitLoot(SocialInteractionExportContext context)
        {
            var tuning = ElementTuning.Create(context.Element, "LearnTraitLoot");
            tuning.Class = "LootActions";
            tuning.InstanceType = "action";
            tuning.Module = "interactions.utils.loot";

            var tuningContext = new TuningActionContext
            {
                DataContext = this,
                Tuning = tuning
            };
            tuningContext.Variables.Add("TraitKey", context.TraitKey.ToString());
            TuningActionInvoker.InvokeFromFile("Learn Trait Loot", tuningContext);

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}