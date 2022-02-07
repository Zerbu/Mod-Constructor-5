using Constructor5.Base.DebugCommandSystem;
using Constructor5.UI.Main;

namespace Constructor5.UI.DebugCommands
{
    [DebugCommand("toggle_show_context_specific")]
    public class ToggleShowContextSpecificCommand : DebugCommandBase
    {
        public override void Invoke(string[] parameters) => MainWindow.ShowContextSpecificElements = !MainWindow.ShowContextSpecificElements;
    }
}