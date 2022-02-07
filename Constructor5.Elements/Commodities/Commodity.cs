using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Elements.Commodities
{
    [ElementTypeData("Commodity", true, ElementTypes = new[] { typeof(Commodity) }, PresetFolders = new[] { "Commodity" })]
    public class Commodity : SimpleComponentElement<CommodityComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Commodity";
            tuning.InstanceType = "statistic";
            tuning.Module = "statistics.commodity";

            foreach (var component in Components)
            {
                component.OnExport(new CommodityExportContext
                {
                    Element = this,
                    Tuning = tuning
                });
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}
