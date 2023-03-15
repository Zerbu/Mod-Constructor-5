using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Social.ContextModifiers;
using Constructor5.Elements.Traits.Components;
using System;

namespace Constructor5.Elements.Interactions.Shared
{
    public abstract class InteractionTemplateComponentBase : InteractionComponent
    {
        public override int ComponentDisplayOrder => 2;
        public override string ComponentLabel => "MainContent";

        public InteractionTemplate Template { get; set; } = new DefaultInteractionTemplate();

        protected internal override void OnExport(InteractionExportContext context)
        {
            var socialContext = context as SocialInteractionExportContext;
            if (socialContext == null)
            {
                return;
            }

            var traitContextModifier = Element.GetContextModifier<SIAssociatedTrait>();
            if (traitContextModifier != null)
            {
                socialContext.TraitKey = (ulong)ElementTuning.GetSingleInstanceKey(traitContextModifier.Trait);

                var component = ((Trait)traitContextModifier.Trait.Element).GetTraitComponent<TraitInfoComponent>();
                if (component.TraitType == TraitTypes.Personality)
                {
                    socialContext.LearnTraitLootKey = CreateLearnTraitLoot(socialContext);
                }
            }

            socialContext.ScoreTypeKey = GetScoreTypeKey(socialContext);

            Template.OnExport(context);
        }

        private ulong GetScoreTypeKey(SocialInteractionExportContext socialContext)
        {
            if (Template.UseCustomScoreType)
            {
                return Template.GetCustomScoreTypeKey(socialContext);
            }

            switch (ElementTuning.GetSingleInstanceKey(Template.PieMenuCategory))
            {
                case 318696: // friendly activities
                    return 24555;
                case 318318: // friendly affection
                    return 318537;
                case 308262: // friendly complaints
                    return 314877;
                case 308258: // friendly compliments
                    return 314876;
                case 308257: // friendly deep thoughts
                    return 314813;
                case 308263: // friendly gossip
                    return 314878;
                case 308260: // friendly hobbies
                    return 314880;
                case 308259: // friendly interests
                    return 314879;
                case 308261: // friendly small talk
                    return 314881;
                case 308256: // friendly stories
                    return 314812;
                case 308253: // funny jokes
                    return 315250;
                case 308254: // funny potty humor
                    return 315251;
                case 308255: // funny silly behavior
                    return 315252;
                case 311656: // funny stories
                    return 315253;
                case 308251: // mean arguments
                    return 324172;
                case 308252: // mean malicious
                    return 314808;
                case 308139: // mischief deception
                    return 314806;
                case 308250: // mischief pranks
                    return 314804;
                case 308138: // romantic affection
                    return 314811;
                case 308137: // romantic flirtation
                    return 314810;
                case 308136: // romantic physical intimacy
                    return 314809;
                case 103107: // tell group story
                    return 314812;
            }

            return Template.GetFallbackScoreType(socialContext);
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
