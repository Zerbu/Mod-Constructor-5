using System.Windows;

namespace Constructor5.UI.Shared
{
    public class TabControl : System.Windows.Controls.TabControl
    {
        public TabControl() => Style = (Style)Application.Current.Resources["TabControlStyle"];
    }
}
