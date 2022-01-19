using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneReferenceListVariantAttribute : AutoTunerAttribute
    {
        public AutoTuneReferenceListVariantAttribute(string tunableName, string variantName = "enabled")
        {
            TunableName = tunableName;
            VariantName = variantName;
        }

        public string TunableName { get; }
        public string VariantName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            var list = (ReferenceList)value;
            if (!list.HasItems())
            {
                return;
            }

            var tunable = tuning.GetVariant<TunableList>(TunableName, VariantName);
            foreach (var item in list.Items)
            {
                foreach (var key in ElementTuning.GetInstanceKeys(item.Reference))
                {
                    tunable.Set<TunableBasic>(null, key);
                }
            }
        }
    }
}
