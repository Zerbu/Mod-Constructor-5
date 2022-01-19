using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Base.ExportSystem.AutoTuners
{
    public static class AutoTunerInvoker
    {
        public static void Invoke(object obj, TuningBase tuning)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(AutoTunerAttribute), true);
                foreach (var attribute in attributes)
                {
                    ((AutoTunerAttribute)attribute).AutoTune(tuning, property.GetValue(obj));
                }
            }
        }
    }
}
