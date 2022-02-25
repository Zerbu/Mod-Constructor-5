using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Super;

namespace Constructor5.InteractionTemplates.TraitPicker
{
    [SelectableObjectType("SuperInteractionTemplates", "TraitPickerInteraction")]
    [XmlSerializerExtraType]
    public class TraitPickerInteractionTemplate : InteractionTemplate, IIsImmediateInteraction
    {
        public override string Label => "Trait Picker Interaction";

        [AutoTuneIfTrue("only_one_allowed")]
        public bool OnlyOneAllowed { get; set; }

        [AutoTuneBasic("category")]
        public Reference PieMenuCategory { get; set; } = new Reference();

        [AutoTuneReferenceList("traits")]
        public ReferenceList Traits { get; set; } = new ReferenceList();

        public string TuningActionsFile { get; set; } = "TraitPickerSuperInteraction";

        protected override void OnExport(InteractionExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            PythonBuilder.AddStep(ImportTraitPickerPythonStep.Current);

            ((TuningHeader)context.Tuning).Class = "CustomTraitPickerSuperInteraction";
            ((TuningHeader)context.Tuning).Module = Project.Id;

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