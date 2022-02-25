using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.Elements.Interactions.Social
{
    [ElementTypeData("SocialInteraction", true, ElementTypes = new[] { typeof(SocialInteraction) }, IsRootType = true)]
    public class SocialInteraction : InteractionElement, IExportableElement, ISupportsCustomTuning
    {
        public SocialInteraction() => SaveVersion = 2;

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SocialMixerInteraction";
            tuning.InstanceType = "interaction";
            tuning.Module = "interactions.social.social_mixer_interaction";

            var context = new SocialInteractionExportContext()
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
            foreach (var type in Reflection.GetTypesWithAttribute<SocialInteractionComponentAttribute>(false))
            {
                AddComponent(type);
            }

            // remove mixer outcome component that was added to earlier versions due to a bug
            var mixerComponent = GetComponent<MixerInteractionTemplateComponent>();
            if (mixerComponent != null)
            {
                Components.Remove(mixerComponent);
            }

            if (SaveVersion == 1)
            {
                var templateComponent = GetComponent<SocialInteractionTemplateComponent>();
                templateComponent.Template.OnSaveUpgrade(SaveVersion, 2);
                SaveVersion = 2;
            }
        }

        protected internal override void TuneTags(InteractionExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("interaction_category_tags");
            tunableList1.Set<TunableEnum>(null, "Interaction_Mixer");
            tunableList1.Set<TunableEnum>(null, "Interaction_All");
            tunableList1.Set<TunableEnum>(null, "Interaction_SocialAll");
            tunableList1.Set<TunableEnum>(null, "Interaction_SocialMixer");
        }
    }
}