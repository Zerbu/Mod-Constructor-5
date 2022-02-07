using Constructor5.Base.ElementSystem;

namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("toggle_context_specific")]
    public class ToggleContextSpecificCommand : ElementCommand
    {
        protected override void InvokeElementCommand(Element element)
            => element.IsContextSpecific = !element.IsContextSpecific;
    }
}