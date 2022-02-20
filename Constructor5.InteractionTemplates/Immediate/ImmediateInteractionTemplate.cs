using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Super;
using System;

namespace Constructor5.InteractionTemplates.Immediate
{
    [SelectableObjectType("SuperInteractionTemplates", "ImmediateInteraction", Description = "ImmediateInteractionNotice")]
    [XmlSerializerExtraType]
    public class ImmediateInteractionTemplate : InteractionTemplate, IIsImmediateInteraction
    {
        public override string Label => "Immediate Interaction";
        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference();

        public string TuningActionsFile { get; set; } = "ImmediateInteraction";

        protected override void OnExport(InteractionExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
            ((TuningHeader)context.Tuning).Class = "ImmediateSuperInteraction";
            ((TuningHeader)context.Tuning).Module = "interactions.base.immediate_interaction";
            RunTuningActions(context, TuningActionsFile);
            TuneImmediateIcon(context);
        }

        private void TuneImmediateIcon(InteractionExportContext context)
        {
            var component = context.Element.GetComponent<InteractionInfoComponent>();
            if (!component.SetPieMenuIcon)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("pie_menu_icon", "enabled");
                var tunableVariant2 = tunableVariant1.Set<TunableVariant>("enabled", "resource_key");
                var tunableTuple1 = tunableVariant2.Get<TunableTuple>("resource_key");
                tunableTuple1.Set<TunableBasic>("key", "2f7d0004:00000000:25eea5cdba6a6fd6");
            }
        }
    }
}
