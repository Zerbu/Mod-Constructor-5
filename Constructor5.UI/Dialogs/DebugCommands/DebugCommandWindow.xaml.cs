using Constructor5.Base.DebugCommandSystem;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Dialogs.DebugCommands
{
    public partial class DebugCommandWindow : Window
    {
        public DebugCommandWindow() => InitializeComponent();

        private void InvokeButton_Click(object sender, RoutedEventArgs e)
        {
            var split = TextBox.Text.Split(' ');

            var splitList = split.ToList();
            splitList.RemoveAt(0);
            DebugCommandManager.Invoke(split[0], splitList.ToArray());

            Close();
        }
    }
}