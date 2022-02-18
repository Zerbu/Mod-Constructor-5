using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneVariantRangeAttribute : AutoTunerAttribute
    {
        public AutoTuneVariantRangeAttribute(string tunableName, string variantName = "enabled", string secondTuple = null)
        {
            TunableName = tunableName;
            VariantName = variantName;
            SecondTuple = secondTuple;
        }

        public int LowerDefaultOverride
        {
            get => _lowerDefaultOverride;
            set
            {
                _lowerDefaultOverride = value;
                EnableLowerOverride = true;
            }
        }

        public string TunableName { get; }
        public string VariantName { get; }
        public string SecondTuple { get; }

        public int UpperDefaultOverride
        {
            get => _upperDefaultOverride;
            set
            {
                _upperDefaultOverride = value;
                EnableUpperOverride = true;
            }
        }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var boundsValue = (IntBounds)value;
            if (!boundsValue.RestrictLowerBound && !boundsValue.RestrictUpperBound)
            {
                if (!EnableLowerOverride && !EnableUpperOverride)
                {
                    return;
                }
            }

            var tunableTuple1 = tuning.GetVariant<TunableTuple>(TunableName, VariantName);
            if (SecondTuple != null)
            {
                tunableTuple1 = tunableTuple1.Get<TunableTuple>(SecondTuple);
            }

            if (boundsValue.RestrictLowerBound)
            {
                tunableTuple1.Set<TunableBasic>("lower_bound", boundsValue.LowerBound);
            }
            else if (EnableLowerOverride)
            {
                tunableTuple1.Set<TunableBasic>("lower_bound", LowerDefaultOverride);
            }

            if (boundsValue.RestrictUpperBound)
            {
                tunableTuple1.Set<TunableBasic>("upper_bound", boundsValue.UpperBound);
            }
            else if (EnableUpperOverride)
            {
                tunableTuple1.Set<TunableBasic>("upper_bound", UpperDefaultOverride);
            }
        }

        private int _lowerDefaultOverride;
        private int _upperDefaultOverride;
        private bool EnableLowerOverride { get; set; }
        private bool EnableUpperOverride { get; set; }
    }
}
