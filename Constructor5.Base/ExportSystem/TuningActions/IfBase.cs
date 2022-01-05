using Constructor5.ActionSystem.TuningActions;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    public abstract class IfBase : TuningAction
    {
        public abstract bool Condition(TuningActionContext context, string propertyName);

        public sealed override void Invoke(TuningActionContext context)
        {
            var condition = Condition(context, context.XmlReader.GetAttribute("p"));
            var isInverted = context.XmlReader.GetAttribute("Inverted")?.ToLower() == "true";
            if (condition && !isInverted || !condition && isInverted)
            {
                TuningActionInvoker.InvokeFromString(context.XmlReader.ReadInnerXml(), new TuningActionContext(context));
            }
            else
            {
                context.XmlReader.Skip();
            }
        }
    }
}
