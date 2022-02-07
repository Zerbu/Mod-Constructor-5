using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("open")]
    public class OpenElementCommand : ElementCommand
    {
        protected override void InvokeElementCommand(Element element) => Hooks.Location<IOnCallOpenElement>(x => x.OnCallOpenElement(element));
    }
}
