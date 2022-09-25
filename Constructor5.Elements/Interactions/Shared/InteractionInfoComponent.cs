using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social.ContextModifiers;
using Constructor5.Elements.Traits.Components;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Super;
using System;

namespace Constructor5.Elements.Interactions.Social
{
    [SocialInteractionComponent]
    [MixerInteractionComponent]
    [SuperInteractionComponent]
    [XmlSerializerExtraType]
    public class InteractionInfoComponent : InteractionComponent
    {
        [AutoTuneIfFalse("allow_autonomous")]
        public bool AllowAutonomous { get; set; } = true;

        [AutoTuneIfFalse("allow_user_directed")]
        public bool AllowUserDirected { get; set; } = true;

        public override int ComponentDisplayOrder => 1;

        public override string ComponentLabel => "Info";

        [AutoTuneIfTrue("cheat")]
        public bool IsCheat { get; set; }

        [AutoTuneIfTrue("visible", "False")]
        public bool IsHiddenInQueue { get; set; }

        [AutoTuneBasic("display_name")]
        public STBLString Name { get; set; } = new STBLString() { CustomText = "Custom Interaction" };

        public STBLString NameOnTarget { get; set; } = new STBLString() { CustomText = "Listen to {1.SimFirstName}'s Custom Interaction" };

        public ElementIcon PieMenuIcon { get; set; } = new ElementIcon();
        public bool SetPieMenuIcon { get; set; }

        protected internal override void OnExport(InteractionExportContext context)
        {
            var icon = (ElementIcon)null;

            if (SetPieMenuIcon)
            {
                icon = PieMenuIcon;
            }
            else
            {
                var traitContextModifier = Element.GetContextModifier<SIAssociatedTrait>();
                if (traitContextModifier != null)
                {
                    icon = ((Trait)traitContextModifier.Trait.Element).GetTraitComponent<TraitInfoComponent>().Icon;
                }
            }

            if (icon != null)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("pie_menu_icon", "enabled");
                var tunableVariant2 = tunableVariant1.Set<TunableVariant>("enabled", "resource_key");
                var tunableTuple1 = tunableVariant2.Get<TunableTuple>("resource_key");
                tunableTuple1.Set<TunableBasic>("key", icon);
            }

            ((InteractionElement)Element).TuneTags(context);

            if (context.Element is SocialInteraction)
            {
                context.Tuning.Set<TunableBasic>("display_name_target", NameOnTarget);
            }

            TuneTextTokens(context);

            AutoTunerInvoker.Invoke(this, context.Tuning);
        }

        private void TuneTextTokens(InteractionExportContext context)
        {
            var tunableTuple1 = context.Tuning.Get<TunableTuple>("display_name_text_tokens");
            var tunableList1 = tunableTuple1.Get<TunableList>("tokens");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "participant_type");
            var tunableTuple2 = tunableVariant1.Get<TunableTuple>("participant_type");
            var tunableVariant2 = tunableTuple2.Set<TunableVariant>("objects", "from_participant");
            var tunableTuple3 = tunableVariant2.Get<TunableTuple>("from_participant");
            tunableTuple3.Set<TunableEnum>("participant", "Actor");
            var tunableVariant3 = tunableList1.Set<TunableVariant>(null, "participant_type");
            var tunableTuple4 = tunableVariant3.Get<TunableTuple>("participant_type");
            var tunableVariant4 = tunableTuple4.Set<TunableVariant>("objects", "from_participant");
            var tunableTuple5 = tunableVariant4.Get<TunableTuple>("from_participant");
            tunableTuple5.Set<TunableEnum>("participant", "Object");
        }
    }
}