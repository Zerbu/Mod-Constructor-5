using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Careers.Components;
using Constructor5.Elements.CareerTracks;
using Constructor5.Elements.Interactions.Career;
using Constructor5.Elements.Statistics;

namespace Constructor5.Elements.Careers
{
    [ElementTypeData("Career", false, ElementTypes = new[] { typeof(Career) }, PresetFolders = new[] { "Career" }, IsRootType = true)]
    public class Career : SimpleComponentElement<CareerComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Career";
            tuning.InstanceType = "career";
            tuning.Module = "careers.career_tuning";

            tuning.SimDataHandler = new SimDataHandler("SimData/Career.data");

            //tuning.SimDataHandler.Write(64, 0);

            foreach (var component in Components)
            {
                component.OnExport(new CareerExportContext { Element = this, Tuning = tuning });
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();

            var infoComponent = GetComponent<CareerInfoComponent>();
            if (infoComponent.PerformanceStatistic == null)
            {
                var newReference = (Statistic)ElementManager.Create(typeof(Statistic), null, true);
                newReference.MinValue = -100;
                newReference.MaxValue = 100;
                newReference.AddContextModifier(new CareerPerformanceStatisticContextModifier() { Career = new Reference(this) });
                infoComponent.PerformanceStatistic = new Reference(newReference);
                newReference.Label = $"{Label} Statistic";
                ElementSaver.ScheduleOneTime(newReference);
            }

            var interactionComponent = GetComponent<CareerInteractionComponent>();
            if (interactionComponent.Interaction == null)
            {
                var newReference = ElementManager.Create(typeof(CareerInteraction), null, true);
                newReference.AddContextModifier(new CareerInteractionContextModifier() { Career = new Reference(this) });
                interactionComponent.Interaction = new Reference(newReference);
                newReference.Label = $"{Label} Career Interaction";
            }

            var levelsComponent = GetComponent<CareerLevelsComponent>();
            if (levelsComponent.BaseTrack == null)
            {
                var newReference = ElementManager.Create(typeof(CareerTrack), null, true);
                newReference.AddContextModifier(new CareerTrackContextModifier() { Career = new Reference(this) });
                levelsComponent.BaseTrack = new Reference(newReference);
                newReference.Label = $"{Label} Career Track";
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var infoComponent = GetComponent<CareerInfoComponent>();
            infoComponent.Name.CustomText = label;
            infoComponent.CompanyNames.Add(new CareerCompanyName { CompanyName = new STBLString() { CustomText = $"The {label} Company" } });
            infoComponent.PTOInteractionName.CustomText = $"Take Vacation Day ({label})";
        }
    }
}