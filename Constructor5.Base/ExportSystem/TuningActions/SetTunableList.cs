using Constructor5.ActionSystem.TuningActions;
using Constructor5.Base.ExportSystem.Tuning;
using System;

namespace Constructor5.Base.ExportSystem.TuningActions
{

    [RegisterTuningAction("L")]
    public class SetTunableList : TuningAction
    {
        public override void Invoke(TuningActionContext context)
        {
            var tuple = context.Tuning.Get<TunableList>(context.XmlReader.GetAttribute("n"));
            TuningActionInvoker.InvokeFromString(context.XmlReader.ReadInnerXml(), new TuningActionContext(context) { Tuning = tuple });
        }
    }
}
