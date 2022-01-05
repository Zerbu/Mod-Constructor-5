using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.Elements.Interactions.Mixer
{
    [ElementTypeData("Mixer Interaction", true, ElementTypes = new[] { typeof(MixerInteraction) })]
    public class MixerInteraction : InteractionElement, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "MixerInteraction";
            tuning.InstanceType = "interaction";
            tuning.Module = "interactions.base.mixer_interaction";

            var context = new MixerInteractionExportContext()
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetTypesWithAttribute<MixerInteractionComponentAttribute>(false))
            {
                AddComponent(type);
            }
        }
    }
}