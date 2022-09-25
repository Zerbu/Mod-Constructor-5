using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System;

namespace Constructor5.Elements.WeeklyScheduleSituationSets
{
    [ElementTypeData("WeeklyScheduleSituationSet", false, ElementTypes = new[] { typeof(WeeklyScheduleSituationSet) }, PresetFolders = new[] { "WeeklyScheduleSituationSet" })]
    public class WeeklyScheduleSituationSet : Element, IExportableElement
    {
        [AutoTuneReferenceList("start_on_time_loot")]
        public ReferenceList LootOnStart { get; set; } = new ReferenceList();

        public ReferenceList RequiredSituations { get; set; } = new ReferenceList();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "WeeklyScheduleSituationSet";
            tuning.InstanceType = "snippet";
            tuning.Module = "venues.weekly_schedule_zone_director";

            var tunableList1 = tuning.Get<TunableList>("required_situations");

            foreach(var situation in RequiredSituations.GetOfType<WeeklyScheduleSituationSetItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(situation.Reference))
                {
                    var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                    tunableTuple1.Set<TunableBasic>("situation_data", key);
                    if (situation.Weight != 1)
                    {
                        var tuple = tunableTuple1.Get<TunableTuple>("weight");
                        tuple.Set<TunableBasic>("base_value", situation.Weight);
                    }
                    if (situation.Unlimited)
                    {
                        var tunableVariant1 = tunableTuple1.Set<TunableVariant>("max_created", "unlimited");
                    }
                }
            }

            AutoTunerInvoker.Invoke(this, tuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}