using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneBasicAttribute : AutoTunerAttribute
    {
        public AutoTuneBasicAttribute(string tunableName) => TunableName = tunableName;

        public object IgnoreIf { get; set; }
        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null || value.Equals(IgnoreIf))
            {
                return;
            }

            tuning.Set<TunableBasic>(TunableName, value);
        }
    }
}
