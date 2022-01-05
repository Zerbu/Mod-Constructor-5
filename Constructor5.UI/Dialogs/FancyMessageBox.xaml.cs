using System.Windows;

namespace Constructor5.UI.Dialogs
{
    /// <summary>
    /// Interaction logic for FancyMessageBox.xaml
    /// </summary>
    public partial class FancyMessageBox : Window
    {
        public FancyMessageBox() => InitializeComponent();

        public static void Show(string text)
        {
            var dialog = new FancyMessageBox() { Owner = DialogUtility.GetOwner() };
            dialog.TextBlock.Text = text;
            dialog.OKButton.Visibility = Visibility.Collapsed;
            dialog.CloseButton.IsDefault = true;
            dialog.ShowDialog();
        }

        public static bool ShowOKCancel(string text)
        {
            var dialog = new FancyMessageBox() { Owner = DialogUtility.GetOwner() };
            dialog.TextBlock.Text = text;
            dialog.CloseButton.Content = "Cancel";
            dialog.OKButton.IsDefault = true;
            dialog.ShowDialog();
            return dialog.OKClicked;
        }

        private bool OKClicked { get; set; }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            OKClicked = true;
            Close();
        }
    }
}