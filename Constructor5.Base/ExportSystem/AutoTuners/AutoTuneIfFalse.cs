using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneIfFalse : AutoTunerAttribute
    {
        public AutoTuneIfFalse(string tunableName, string tunableValue = "False")
        {
            TunableName = tunableName;
            TunableValue = tunableValue;
        }

        public string TunableName { get; }
        public string TunableValue { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var boolValue = (bool)value;
            if (!boolValue)
            {
                tuning.Set<TunableBasic>(TunableName, TunableValue);
            }
        }
    }
}
