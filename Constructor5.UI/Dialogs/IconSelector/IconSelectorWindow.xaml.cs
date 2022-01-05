using Constructor5.Base.Icons;
using System;
using System.Windows;

namespace Constructor5.UI.Dialogs.IconSelector
{
    /// <summary>
    /// Interaction logic for IconSelectorWindow.xaml
    /// </summary>
    public partial class IconSelectorWindow : Window
    {
        public IconSelectorWindow() => InitializeComponent();

        public event Action<ElementIcon> ImageSelected;

        private void GameImageSelector_ImageSelected(ElementIcon icon)
        {
            ImageSelected.Invoke(icon);
            Close();
        }

        private void CustomImageSelector_ImageSelected(ElementIcon icon)
        {
            ImageSelected.Invoke(icon);
            Close();
        }
    }
}
