using Constructor5.Base.ExportSystem.Tuning;
using System;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public abstract class AutoTunerAttribute : Attribute
    {
        public abstract void AutoTune(TuningBase tuning, object value);
    }
}
