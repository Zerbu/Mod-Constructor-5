using Constructor5.Base.ElementSystem;
using System.Linq;

namespace Constructor5.Base.DebugCommandSystem
{
    public abstract class ElementCommand : DebugCommandBase
    {
        public override sealed void Invoke(string[] parameters)
        {
            if (parameters.Count() == 0)
            {
                InvokeElementCommand(ElementManager.FocusedElement);
                return;
            }

            var elementId = parameters[0];
            var element = ElementManager.GetAll().FirstOrDefault(x => x.UserFacingId == elementId);
            if (element == null)
            {
                element = ElementManager.GetAll().FirstOrDefault(x => x.Label == elementId);
            }
            if (element == null)
            {
                return;
            }

            InvokeElementCommand(element);
        }

        protected abstract void InvokeElementCommand(Element element);
    }
}