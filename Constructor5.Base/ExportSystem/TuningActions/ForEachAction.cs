using Constructor5.ActionSystem.TuningActions;
using System.Collections;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [RegisterTuningAction("ForEach")]
    public class ForEachAction : TuningAction
    {
        public override void Invoke(TuningActionContext context)
        {
            var propertyName = context.XmlReader.GetAttribute("p");

            var content = context.XmlReader.ReadInnerXml();

            foreach (var item in PropertyExport.GetProperty<IEnumerable>(context.DataContext, propertyName))
            {
                TuningActionInvoker.InvokeFromString(content, new TuningActionContext(context) { DataContext = item });
            }
        }
    }
}
