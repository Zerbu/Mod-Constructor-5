using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("reload")]
    public class ReloadCommand : DebugCommandBase
    {
        public override void Invoke(string[] parameters)
        {
            ElementSaver.SaveScheduled();

            if (parameters.Count() == 0)
            {
                Process.Start(Process.GetCurrentProcess().MainModule.FileName, Project.Id);
                Application.Current.Shutdown();
                return;
            }

            Process.Start(Process.GetCurrentProcess().MainModule.FileName, parameters[0]);
            Application.Current.Shutdown();
        }
    }
}
