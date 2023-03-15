using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;

namespace Constructor5.Elements.ZoneDirectors
{
    [ElementTypeData("ZoneDirector", true, ElementTypes = new[] { typeof(ZoneDirector) }, PresetFolders = new[] { "ZoneDirector" }, IsRootType = true)]
    public class ZoneDirector : SimpleComponentElement<ZoneDirectorComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SchedulingZoneDirector";
            tuning.InstanceType = "zone_director";
            tuning.Module = "venues.scheduling_zone_director";

            var context = new ZoneDirectorExportContext
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
            foreach (var type in Reflection.GetSubtypes(typeof(ZoneDirectorComponent)))
            {
                AddComponent(type);
            }
        }
    }
}
