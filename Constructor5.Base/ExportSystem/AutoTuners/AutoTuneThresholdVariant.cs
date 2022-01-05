using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public class AutoTuneThresholdVariant : AutoTunerAttribute
    {
        public AutoTuneThresholdVariant(string tunableName) => TunableName = tunableName;

        public string TunableName { get; }

        public override void AutoTune(TuningBase tuning, object value)
        {
            if (value == null)
            {
                return;
            }

            var thresholdValue = (Threshold)value;

            var tunableTuple1 = tuning.GetVariant<TunableTuple>("threshold", "enabled");
            if (thresholdValue.Comparison != ThresholdComparison.GREATER_OR_EQUAL)
            {
                tunableTuple1.Set<TunableEnum>("comparison", thresholdValue.Comparison.ToString());
            }

            tunableTuple1.Set<TunableBasic>("value", thresholdValue.Amount);
        }
    }
}
