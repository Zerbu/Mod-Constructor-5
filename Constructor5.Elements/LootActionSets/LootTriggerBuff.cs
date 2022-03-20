using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Elements.LootActionSets
{
    public static class LootTriggerBuff
    {
        public static ulong Create(Element parentElement, string suffix, ulong[] actionSets)
        {
            var tuning = ElementTuning.Create(parentElement, suffix);
            tuning.Class = "Buff";
            tuning.InstanceType = "buff";
            tuning.Module = "buffs.buff";

            var tunableVariant1 = tuning.Set<TunableVariant>("_temporary_commodity_info", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            tunableTuple1.Set<TunableBasic>("max_duration", "1");
            var tunableList1 = tuning.Get<TunableList>("_loot_on_addition");
            foreach(var actionSet in actionSets)
            {
                tunableList1.Set<TunableBasic>(null, actionSet);
            }
            
            tuning.Set<TunableBasic>("visible", "False");

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}