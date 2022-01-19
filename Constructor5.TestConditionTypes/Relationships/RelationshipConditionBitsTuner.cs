using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.TestConditionTypes.Relationships
{
    public static class RelationshipConditionBitsTuner
    {
        public static void TuneBits(TunableBase tuning, ReferenceList requiredAll, ReferenceList requiredAny, ReferenceList prohibitedAll, ReferenceList prohibitedAny)
        {
            if (requiredAll.HasItems() || requiredAny.HasItems())
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("required_relationship_bits");

                if (requiredAny.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_any");
                    foreach (var key in ElementTuning.GetInstanceKeys(requiredAny))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }

                if (requiredAll.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_all");
                    foreach (var key in ElementTuning.GetInstanceKeys(requiredAll))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }
            }

            if (prohibitedAll.HasItems() || prohibitedAny.HasItems())
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("prohibited_relationship_bits");

                if (prohibitedAny.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_any");
                    foreach (var key in ElementTuning.GetInstanceKeys(prohibitedAny))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }

                if (prohibitedAll.HasItems())
                {
                    var tunableList1 = tunableTuple1.Get<TunableList>("match_all");
                    foreach (var key in ElementTuning.GetInstanceKeys(prohibitedAll))
                    {
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }
            }
        }
    }
}
