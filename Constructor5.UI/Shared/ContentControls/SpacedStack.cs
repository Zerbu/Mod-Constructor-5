using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public class SpacedStack : ItemsControl
    {
        public bool TopMargin
        {
            set => Margin = new Thickness(0, 15, 0, 0);
        }
    }
}
