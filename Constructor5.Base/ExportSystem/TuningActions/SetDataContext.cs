using Constructor5.ActionSystem.TuningActions;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("SetDataContext")]
    public class SetDataContext : TuningAction
    {
        public override void Invoke(TuningActionContext context)
        {
            var propertyName = context.XmlReader.GetAttribute("p");
            TuningActionInvoker.InvokeFromString(context.XmlReader.ReadInnerXml(), new TuningActionContext(context)
            {
                DataContext = PropertyExport.GetProperty<object>(context.DataContext, propertyName)
            });
        }
    }
}
