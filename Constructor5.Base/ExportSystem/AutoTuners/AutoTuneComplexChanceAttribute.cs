using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneComplexChanceAttribute : AutoTunerAttribute
    {
        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var chanceValue = (ComplexChance)value;

            if (chanceValue.BaseChance != 100)
            {
                var tunableTuple1 = tuning.Get<TunableTuple>("chance");
                tunableTuple1.Set<TunableBasic>("base_chance", chanceValue.BaseChance);
            }
        }
    }
}
