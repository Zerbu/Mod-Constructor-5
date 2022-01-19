using System;
using System.Windows;

namespace Constructor5.UI.Dialogs.ExceptionDialog
{
    /// <summary>
    /// Interaction logic for ExceptionDialogWindow.xaml
    /// </summary>
    public partial class ExceptionDialogWindow : Window
    {
        public ExceptionDialogWindow() => InitializeComponent();

        public static void Show(Exception exception, string textBlockOverride = null)
        {
            var dialog = new ExceptionDialogWindow();
            dialog.ErrorTextBox.Text = exception.Message+"\n\n"+exception.StackTrace;
            if (textBlockOverride != null)
            {
                dialog.TextBlock.Text = textBlockOverride;
            }
            dialog.ShowDialog();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        => System.Diagnostics.Process.Start("https://github.com/Zerbu/Mod-Constructor-5/issues");
    }
}