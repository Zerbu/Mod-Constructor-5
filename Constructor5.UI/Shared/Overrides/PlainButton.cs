using System.Windows;

namespace Constructor5.UI.Shared
{
    public class PlainButton : Button
    {
        public PlainButton() => Style = (Style)Application.Current.Resources["Constructor.PlainButtonStyle"];
    }
}
