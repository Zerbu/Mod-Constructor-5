using Constructor5.Base;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using Constructor5.Base.Python;
using Constructor5.Core;
using Constructor5.UI.Dialogs.PythonInstaller;
using Constructor5.UI.Dialogs.UnlocalizableStringFinder;
using Constructor5.UI.Main;
using System.Windows;

namespace Constructor5.UI.Launcher
{
    /// <summary>
    /// Interaction logic for LauncherWindow.xaml
    /// </summary>
    public partial class LauncherWindow : Window, IOnProjectCreatedOrLoaded, IOnProjectCreateError
    {
        public LauncherWindow()
        {
            InitializeComponent();
            Hooks.RegisterClass(this);
            CreatorName.Text = ProgramSettings.CreatorName;
            ProjectsControl.ItemsSource = ProjectManager.LoadInfo();
#if DEBUG
            Hooks.RegisterClass(UnlocalizableStringFinderProcess.Current);
#endif
        }

        void IOnProjectCreatedOrLoaded.OnProjectCreatedOrLoaded()
        {
            new MainWindow().Show();
            Close();
        }

        void IOnProjectCreateError.OnProjectCreateError(ProjectCreateErrorType errorType)
        {
            ErrorMessage.Visibility = Visibility.Visible;
            switch (errorType)
            {
                case ProjectCreateErrorType.FileAlreadyExists:
                    ErrorText.Text = "The project already exists.";
                    break;

                case ProjectCreateErrorType.InvalidCreatorName:
                    ErrorText.Text = "The creator name is invalid.";
                    break;

                case ProjectCreateErrorType.InvalidName:
                    ErrorText.Text = "The mod name is invalid.";
                    break;
            }
        }

        private void ShowPythonInstaller()
        {
            if (PythonInstallationHelper.GetPath() == null)
            {
                new PythonInstallerWindow() { Owner = this }.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => ShowPythonInstaller();
    }
}