using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Elements.Statistics
{
    [ElementTypeData("Statistic", true, ElementTypes = new[] { typeof(Statistic) }, PresetFolders = new[] { "Statistic", "Commodity", "Skill", "SimInfoStatistic", "Need" })]
    public class Statistic : Element, IExportableElement
    {
        public int InitialValue { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Statistic";
            tuning.InstanceType = "statistic";
            tuning.Module = "statistics.statistic";

            var tunableTuple1 = tuning.Get<TunableTuple>("initial_tuning");
            tunableTuple1.Set<TunableBasic>("_initial_value", InitialValue);
            tunableTuple1.Set<TunableBasic>("_use_stat_value_on_init", "True");
            tuning.Set<TunableBasic>("max_value_tuning", MaxValue);
            tuning.Set<TunableBasic>("min_value_tuning", MinValue);

            tuning.SimDataHandler = new SimDataHandler("SimData/Statistic.data");
            tuning.SimDataHandler.Write(64, MaxValue);
            tuning.SimDataHandler.Write(68, MinValue);

            TuningExport.AddToQueue(tuning);
        }

        /*protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
        }*/
    }
}
