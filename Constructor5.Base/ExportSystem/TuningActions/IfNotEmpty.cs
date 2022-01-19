using Constructor5.ActionSystem.TuningActions;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("IfNotEmpty")]
    public class IfNotEmpty : IfBase
    {
        public override bool Condition(TuningActionContext context, string propertyName)
            => !string.IsNullOrEmpty(PropertyExport.GetString(context.DataContext, propertyName));
    }
}
