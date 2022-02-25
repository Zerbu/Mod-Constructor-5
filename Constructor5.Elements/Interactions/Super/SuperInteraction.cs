using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.Elements.Interactions.Super
{
    [ElementTypeData("SuperInteraction", true, ElementTypes = new[] { typeof(SuperInteraction) }, IsRootType = true)]
    public class SuperInteraction : InteractionElement, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SuperInteraction";
            tuning.InstanceType = "interaction";
            tuning.Module = "interactions.base.super_interaction";

            var context = new SuperInteractionExportContext()
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetTypesWithAttribute<SuperInteractionComponentAttribute>(false))
            {
                AddComponent(type);
            }
        }

        protected internal override void TuneTags(InteractionExportContext context)
        {
            var templateComponent = GetComponent<SuperInteractionTemplateComponent>();
            if (templateComponent.Template is IIsImmediateInteraction)
            {
                context.Tuning.Get<TunableList>("interaction_category_tags").Set<TunableEnum>(null, "INVALID");
                return;
            }
            var tunableList1 = context.Tuning.Get<TunableList>("interaction_category_tags");
            tunableList1.Set<TunableEnum>(null, "Interaction_Super");
            tunableList1.Set<TunableEnum>(null, "Interaction_All");
        }
    }
}
