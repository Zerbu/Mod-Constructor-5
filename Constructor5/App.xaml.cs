using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Startup;
using Constructor5.Core;
using Constructor5.UI.Dialogs.ExceptionDialog;
using Constructor5.UI.Dialogs.UnlocalizableStringFinder;
using Constructor5.UI.Launcher;
using Constructor5.UI.Main;
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
#if !DEBUG
            DispatcherUnhandledException += App_OnDispatcherUnhandledException;
#endif
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StartupEvents.OnStartup();

#if DEBUG
            Hooks.RegisterClass(UnlocalizableStringFinderProcess.Current);
#endif

            if (e.Args.Length > 0)
            {
                ProjectManager.LoadProject(e.Args[0]);
                new MainWindow().Show();
                return;
            }

            new LauncherWindow().Show();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ExceptionDialogWindow.Show(e.Exception);
            e.Handled = true;
        }
    }
}
