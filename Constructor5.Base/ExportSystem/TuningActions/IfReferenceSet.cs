using Constructor5.Base.ElementSystem;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("IfReferenceSet")]
    public class IfReferenceSet : IfBase
    {
        public override bool Condition(TuningActionContext context, string propertyName)
        {
            var reference = (Reference)context.DataContext.GetType().GetProperty(propertyName).GetValue(context.DataContext);
            return reference.Element != null || reference.GameReference != 0;
        }
    }
}