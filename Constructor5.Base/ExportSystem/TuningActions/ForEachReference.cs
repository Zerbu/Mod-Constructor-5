using Constructor5.ActionSystem.TuningActions;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System;
using System.Collections;

namespace Constructor5.Base.ExportSystem.TuningActions
{

    [RegisterTuningAction("ForEachReference")]
    public class ForEachReference : TuningAction
    {
        public override void Invoke(TuningActionContext context)
        {
            var propertyName = context.XmlReader.GetAttribute("p");

            var content = context.XmlReader.ReadInnerXml();

            foreach (var item in PropertyExport.GetProperty<ReferenceList>(context.DataContext, propertyName).Items)
            {
                foreach(var tunableValue in ElementTuning.GetInstanceKeys(item.Reference))
                {
                    context.SetVariable("v", tunableValue.ToString());
                    TuningActionInvoker.InvokeFromString(content, new TuningActionContext(context) { DataContext = item });
                }
            }
        }
    }
}
