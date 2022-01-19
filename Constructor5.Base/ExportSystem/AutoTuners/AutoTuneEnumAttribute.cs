using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneEnumAttribute : AutoTunerAttribute
    {
        public AutoTuneEnumAttribute(string tunableName) => TunableName = tunableName;

        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            tuning.Set<TunableEnum>(TunableName, value);
        }
    }
}
