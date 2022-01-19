using Constructor5.ActionSystem.TuningActions;
using System;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("IfBool")]
    public class IfBool : IfBase
    {
        public override bool Condition(TuningActionContext context, string propertyName)
            => PropertyExport.GetProperty<bool>(context.DataContext, propertyName);
    }
}
