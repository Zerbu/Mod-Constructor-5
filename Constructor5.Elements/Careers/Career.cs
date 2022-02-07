using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Careers.Components;
using Constructor5.Elements.CareerTracks;

namespace Constructor5.Elements.Careers
{
    [ElementTypeData("Career", false, ElementTypes = new[] { typeof(Career) }, PresetFolders = new[] { "Career" }, IsRootType = true)]
    public class Career : SimpleComponentElement<CareerComponent>, IExportableElement
    {
        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Career";
            tuning.InstanceType = "career";
            tuning.Module = "careers.career_tuning";

            foreach (var component in Components)
            {
                component.OnExport(new CareerExportContext { Element = this, Tuning = tuning });
            }

            TuningExport.AddToQueue(tuning);

            // REMINDER: CUSTOM TUNING
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();

            var levelsComponent = GetComponent<CareerLevelsComponent>();
            if (levelsComponent.BaseTrack != null)
            {
                return;
            }

            var newReference = ElementManager.Create(typeof(CareerTrack), null, true);
            newReference.AddContextModifier(new CareerTrackContextModifier() { Career = new Reference(this) });
            levelsComponent.BaseTrack = new Reference(newReference);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var infoComponent = GetComponent<CareerInfoComponent>();
            infoComponent.Name.CustomText = label;
            infoComponent.CompanyNames.Add(new CareerCompanyName { CompanyName = new STBLString() { CustomText = $"The {label} Company" } });
        }
    }
}