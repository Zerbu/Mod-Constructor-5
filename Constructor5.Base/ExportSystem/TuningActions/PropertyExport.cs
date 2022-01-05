using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    public static class PropertyExport
    {
        public static T GetProperty<T>(object obj, string propName)
        {
            var result = obj.GetType().GetProperty(propName).GetValue(obj);
            if (result != null && result is T)
            {
                return (T)result;
            }

            return default(T);
        }

        public static string GetString(object obj, string propName)
        {
            var prop = obj.GetType().GetProperty(propName) ?? throw new NullReferenceException($"Property {propName} not found");

            var result = prop.GetValue(obj);
            
            if (result == null)
            {
                return null;
            }

            if (result is ITunableValueObject tunableValueObject)
            {
                return tunableValueObject.GetTunableValue();
            }

            return result.ToString();
        }
    }
}
