using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AddEnumToListIfTrue : AutoTunerAttribute
    {
        public AddEnumToListIfTrue(string listName, string value)
        {
            ListName = listName;
            Value = value;
        }

        public string ListName { get; }
        public string Value { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if ((bool)value)
            {
                tuning.Get<TunableList>(ListName).Set<TunableEnum>(null, Value);
            }
        }
    }
}
