using Constructor5.Base.Python;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Constructor5.UI.Dialogs.PythonInstaller
{
    /// <summary>
    /// Interaction logic for PythonInstallerWindow.xaml
    /// </summary>
    public partial class PythonInstallerWindow : Window
    {
        public PythonInstallerWindow() => InitializeComponent();

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var path = PythonInstallationHelper.GetPath();
            if (path == null)
            {
                MessageBox.Show("Please wait for the installation to finish.", "Python Not Installed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Close();
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start($"{Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)}/Python Installer/python-3.7.0-amd64.exe");
            ContinueButton.IsEnabled = true;
        }
    }
}