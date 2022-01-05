using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.Shared
{
    public static class WhimSetBuilder
    {
        public static TuningHeader BuildWhimSet(string tuningName, STBLString reason, ReferenceList whims, int priority)
        {
            var tuning = new TuningHeader
            {
                Class = "ObjectivelessWhimSet",
                InstanceType = "aspiration",
                Module = "whims.whim_set",
                Name = tuningName,
                InstanceKey = FNVHasher.FNV32(tuningName, true)
            };

            tuning.Set<TunableBasic>("priority", priority);
            tuning.Set<TunableBasic>("whim_reason", reason);
            var tunableList1 = tuning.Get<TunableList>("whims");

            foreach (var whim in ElementTuning.GetInstanceKeys(whims))
            {
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("goal", whim);
            }

            TuningExport.AddToQueue(tuning);

            return tuning;
        }
    }
}
