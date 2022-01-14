using System.Windows;

namespace Constructor5.UI.Shared
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        public TextBox() => Style = (Style)Application.Current.Resources["TextBoxDefaultStyle"];
    }
}
