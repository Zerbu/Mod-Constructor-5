using System.Windows;

namespace Constructor5.UI.Dialogs
{
    /// <summary>
    /// Interaction logic for FancyInputBox.xaml
    /// </summary>
    public partial class FancyInputBox : Window
    {
        public FancyInputBox() => InitializeComponent();

        public static string Show(string text, string initialValue)
        {
            var dialog = new FancyInputBox() { Owner = DialogUtility.GetOwner() };
            dialog.TextBlock.Text = text;
            dialog.TextBox.Text = initialValue;
            dialog.TextBox.SelectionLength = dialog.TextBox.Text.Length;
            dialog.ShowDialog();
            return dialog.ResultText;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            ResultText = TextBox.Text;
            Close();
        }

        private string ResultText { get; set; }
    }
}