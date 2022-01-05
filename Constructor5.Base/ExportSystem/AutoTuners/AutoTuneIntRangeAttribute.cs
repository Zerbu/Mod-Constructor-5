using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneIntRangeAttribute : AutoTunerAttribute
    {
        public AutoTuneIntRangeAttribute(string tunableName) => TunableName = tunableName;

        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var boundsValue = (IntBounds)value;
            if (!boundsValue.RestrictLowerBound && !boundsValue.RestrictUpperBound)
            {
                return;
            }

            var tunableVariant1 = tuning.Set<TunableVariant>(TunableName, "int_range");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("int_range");
            var tunableTuple2 = tunableTuple1.Get<TunableTuple>("value_range");

            if (boundsValue.RestrictLowerBound)
            {
                tunableTuple2.Set<TunableBasic>("lower_bound", boundsValue.LowerBound);
            }
            
            if (boundsValue.RestrictUpperBound)
            {
                tunableTuple2.Set<TunableBasic>("upper_bound", boundsValue.UpperBound);
            }
        }
    }
}
