using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneReferenceListAttribute : AutoTunerAttribute
    {
        public AutoTuneReferenceListAttribute(string tunableName) => TunableName = tunableName;

        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            var list = (ReferenceList)value;
            if (!list.HasItems())
            {
                return;
            }

            var tunable = tuning.Get<TunableList>(TunableName);
            foreach(var item in list.Items)
            {
                foreach(var key in ElementTuning.GetInstanceKeys(item.Reference))
                {
                    tunable.Set<TunableBasic>(null, key);
                }
            }
        }
    }
}
