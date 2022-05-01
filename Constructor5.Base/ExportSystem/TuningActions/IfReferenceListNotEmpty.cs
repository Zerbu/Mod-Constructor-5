using Constructor5.Base.ElementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("IfReferenceListNotEmpty")]
    public class IfReferenceListNotEmpty : IfBase
    {
        public override bool Condition(TuningActionContext context, string propertyName)
        {
            var list = (ReferenceList)context.DataContext.GetType().GetProperty(propertyName).GetValue(context.DataContext);
            if (list == null)
            {
                return false;
            }

            if (list.HasItems())
            {
                return true;
            }
            return false;
        }
    }
}
