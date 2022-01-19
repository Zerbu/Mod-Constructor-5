using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.LotTraits
{
    [ElementTypeData("LotTrait", true, ElementTypes = new[] { typeof(LotTrait) }, PresetFolders = new[] { "LotTrait" }, IsRootType = true)]
    public class LotTrait : SimpleComponentElement<LotTraitComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "ZoneModifier";
            tuning.InstanceType = "zone_modifier";
            tuning.Module = "zone_modifier.zone_modifier";

            tuning.SimDataHandler = new SimDataHandler($"SimData/LotTrait.data");

            var context = new LotTraitExportContext
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
            foreach (var type in Reflection.GetSubtypes(typeof(LotTraitComponent)))
            {
                AddComponent(type);
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetComponent<LotTraitInfoComponent>();
            info.Name = new STBLString() { CustomText = label };
        }
    }
}