using Constructor5.Base.ElementSystem;
using System.Diagnostics;
using System.Windows;

namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("restart")]
    public class RestartCommand : DebugCommandBase
    {
        public override void Invoke(string[] parameters)
        {
            ElementSaver.SaveScheduled();

            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Application.Current.Shutdown();
        }
    }
}
