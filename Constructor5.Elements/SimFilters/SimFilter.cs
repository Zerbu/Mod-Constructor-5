using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.SimFilters
{
    [ElementTypeData("Sim Filter", false, ElementTypes = new[] { typeof(SimFilter) }, PresetFolders = new[] { "SimFilter" })]
    public class SimFilter : Element, IExportableElement
    {
        public ObservableCollection<SimFilterTermItem> Terms { get; } = new ObservableCollection<SimFilterTermItem>();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "TunableSimFilter";
            tuning.InstanceType = "sim_filter";
            tuning.Module = "filters.tunable";

            var tunableList1 = tuning.Get<TunableList>("_filter_terms");

            foreach(var term in Terms)
            {
                term.Term.OnExport(tunableList1);
            }

            var tunableVariant2 = tuning.Set<TunableVariant>("_household_templates_override", "enabled");
            var tunableList2 = tunableVariant2.Get<TunableList>("enabled");
            tunableList2.Set<TunableBasic>(null, "98542");
            tuning.Set<TunableBasic>("_template_chooser", "");
            tuning.Set<TunableBasic>("use_weighted_random", "True");

            TuningExport.AddToQueue(tuning);
        }
    }
}
