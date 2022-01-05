using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;

namespace Constructor5.Elements.Buffs.Components
{
    public static class BuffLootOnIntervalBuilder
    {
        public static ulong AddToCommodity(BuffExportContext context, int intervalMin, int intervalMax, Reference reference)
        {
            var tuningName = ElementTuning.GetFullName(context.Element, $"Interval-{intervalMin}-{intervalMax}");

            if (!context.IntervalCommodities.ContainsKey(tuningName))
            {
                CreateMainCommodity(context, intervalMin, intervalMax);
            }

            var tuning = context.IntervalCommodities[tuningName];

            var lootOnEnter = tuning.Get<TunableList>("states").Tunables[0].Get<TunableList>("loot_list_on_enter_always");
            foreach (var key in ElementTuning.GetInstanceKeys(reference))
            {
                lootOnEnter.Set<TunableBasic>(null, key);
            }

            return tuning.InstanceKey;
        }

        private static void CreateMainCommodity(BuffExportContext context, int intervalMin, int intervalMax)
        {
            var tuning = ElementTuning.Create(context.Element, $"Interval-{intervalMin}-{intervalMax}");
            tuning.Class = "Commodity";
            tuning.InstanceType = "statistic";
            tuning.Module = "statistics.commodity";

            TuningActionInvoker.InvokeFromFile("Loot On Interval Main Commodity",
                new TuningActionContext
                {
                    Tuning = tuning,
                    DataContext = null,
                    Variables =
                    {
                            { "RefreshLoot", CreateRefreshLoot(context, $"{tuning.Name}:Loot", tuning.InstanceKey).ToString() }
                    }
                });

            // not exported until later

            context.IntervalCommodities.Add(tuning.Name, tuning);
            context.CommodityKeysToAdd.Add(tuning.InstanceKey);
        }

        private static ulong CreateRefreshLoot(BuffExportContext context, string tuningName, ulong commodityInstanceKey)
        {
            var tuning = new TuningHeader
            {
                Class = "LootActions",
                InstanceType = "action",
                Module = "interactions.utils.loot",
                Name = tuningName,
                InstanceKey = FNVHasher.FNV32(tuningName, true)
            };

            TuningActionInvoker.InvokeFromFile("Loot On Interval Refresh Loot",
                new TuningActionContext
                {
                    Tuning = tuning,
                    DataContext = null,
                    Variables =
                    {
                        { "Commodity", commodityInstanceKey.ToString() }
                    }
                });

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}
