using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

namespace Constructor5.Elements.Buffs.References
{
    public class AutoTuneBuffWithReasonTupleAttribute : AutoTunerAttribute
    {
        public AutoTuneBuffWithReasonTupleAttribute(string tunableName) => TunableName = tunableName;

        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var buffWithReason = (BuffWithReason)value;

            var key = ElementTuning.GetSingleInstanceKey(buffWithReason.Buff);
            if (key != null)
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("buff");
                tunableTuple1.Set<TunableBasic>("buff_type", key);
                if (!string.IsNullOrEmpty(buffWithReason.Reason.CustomText))
                {
                    var tunableVariant1 = tunableTuple1.Set<TunableVariant>("buff_reason", "enabled");
                    tunableVariant1.Set<TunableBasic>("enabled", buffWithReason.Reason);
                }
            }
        }
    }
}
