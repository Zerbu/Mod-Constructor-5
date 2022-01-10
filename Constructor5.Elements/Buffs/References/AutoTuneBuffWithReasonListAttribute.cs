using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Elements.Buffs.References
{
    public class AutoTuneBuffWithReasonListAttribute : AutoTunerAttribute
    {
        public AutoTuneBuffWithReasonListAttribute(string tunableName) => TunableName = tunableName;

        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var list = tuning.Get<TunableList>(TunableName);

            var refList = (ReferenceList)value;
            foreach (var item in refList.GetOfType<BuffWithReasonReferenceListItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(item.Reference))
                {
                    var tunableTuple1 = list.Get<TunableTuple>(null);
                    tunableTuple1.Set<TunableBasic>("buff_type", key);
                    if (!string.IsNullOrEmpty(item.Reason.CustomText))
                    {
                        var tunableVariant1 = tunableTuple1.Set<TunableVariant>("buff_reason", "enabled");
                        tunableVariant1.Set<TunableBasic>("enabled", item.Reason);
                    }
                }
            }
        }
    }
}