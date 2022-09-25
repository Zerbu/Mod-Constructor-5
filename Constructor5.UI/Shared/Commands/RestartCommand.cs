using Constructor5.Base.ElementSystem;
using Constructor5.UI.Bases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class RestartCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            ElementSaver.SaveScheduled();

            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Application.Current.Shutdown();
        }
    }
}
