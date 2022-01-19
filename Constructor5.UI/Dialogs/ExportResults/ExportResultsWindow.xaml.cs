using Constructor5.Base.ExportSystem;
using System.Windows;

namespace Constructor5.UI.Dialogs.ExportResults
{
    /// <summary>
    /// Interaction logic for ExportResultsWindow.xaml
    /// </summary>
    public partial class ExportResultsWindow : Window
    {
        public ExportResultsWindow() => InitializeComponent();

        public ExportResultsWindow(ExportResultsData results)
        {
            InitializeComponent();
            DataContext = results;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}