using System.Windows;

namespace Constructor5.DebugTools.ObjectFromTDescConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void ClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            var clipboardText = $"<I>{Clipboard.GetText(TextDataFormat.Text)}</I>";
            var converter = new Converter { Text = clipboardText };
            converter.Convert();
            TextBox.Text = converter.Outcome.ToString();
        }
    }
}