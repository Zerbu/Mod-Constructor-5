using System.Collections;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("IfListNotEmpty")]
    public class IfListNotEmpty : IfBase
    {
        public override bool Condition(TuningActionContext context, string propertyName)
        {
            var list = (IEnumerable)context.DataContext.GetType().GetProperty(propertyName).GetValue(context.DataContext);
            if (list == null)
            {
                return false;
            }

            foreach (var item in list)
            {
                return true;
            }
            return false;
        }
    }
}