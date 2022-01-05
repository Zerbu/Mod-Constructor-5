using Constructor5.ActionSystem.TuningActions;
using Constructor5.Base.ExportSystem.Tuning;
using System;

namespace Constructor5.Base.ExportSystem.TuningActions
{

    [RegisterTuningAction("V")]
    public class SetTunableVariant : TuningAction
    {
        public override void Invoke(TuningActionContext context)
        {
            var variant = context.Tuning.Get<TunableVariant>(context.XmlReader.GetAttribute("n"));
            variant.Variant = context.XmlReader.GetAttribute("t");
            TuningActionInvoker.InvokeFromString(context.XmlReader.ReadInnerXml(), new TuningActionContext(context) { Tuning = variant });
        }
    }
}
