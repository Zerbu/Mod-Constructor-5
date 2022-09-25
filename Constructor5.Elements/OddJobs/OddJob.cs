using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.OddJobs.Components;

namespace Constructor5.Elements.OddJobs
{
    [ElementTypeData("OddJob", true, ElementTypes = new[] { typeof(OddJob) }, PresetFolders = new[] { "OddJob" }, IsRootType = true)]
    public class OddJob : SimpleComponentElement<OddJobComponent>, IExportableElement, ISupportsCustomTuning
    {
        public OddJob()
        {
            SaveVersion = 2;
        }

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "RabbitholeGig";
            tuning.InstanceType = "career_gig";
            tuning.Module = "careers.rabbithole_career_gig";

            var context = new OddJobExportContext
            {
                Element = this,
                Tuning = tuning
            };
            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            var isAssignment = GetComponent<OddJobAssignmentsComponent>().IsAssignmentJob;
            tuning.SimDataHandler = isAssignment ? new SimDataHandler("SimData/CareerGigAssignment.data") : new SimDataHandler("SimData/CareerGig.data");
            //ExportManager.ExportComponents(element, tuning, null);
            //ExportManager.Current.QueueTGIResource(simDataHandler.Stream, 0x545AC67A, tuning.InstanceKey, FNVHasher.FNV24(tuning.InstanceType));

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(OddJobComponent)))
            {
                AddComponent(type);
            }
            if (SaveVersion == 1)
            {
                GetComponent<OddJobInfoComponent>().SaveUpgrade();
                SaveVersion = 2;
            }
        }
    }
}
