using Constructor5.ActionSystem.TuningActions;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("IfString")]
    public class IfString : IfBase
    {
        public override bool Condition(TuningActionContext context, string propertyName)
            => PropertyExport.GetString(context.DataContext, propertyName) == context.XmlReader.GetAttribute("v");
    }
}
