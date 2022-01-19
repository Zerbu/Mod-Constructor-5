using Constructor5.Base.Startup;
using Constructor5.UI.Dialogs.ExceptionDialog;
using System.Windows;
using System.Windows.Threading;

namespace Constructor5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
//#if !DEBUG
            DispatcherUnhandledException += App_OnDispatcherUnhandledException;
//#endif
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StartupEvents.OnStartup();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ExceptionDialogWindow.Show(e.Exception);
            e.Handled = true;
        }
    }
}
