using Constructor5.Base.Icons;
using Constructor5.UI.Dialogs.IconSelector;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for IconControl.xaml
    /// </summary>
    public partial class IconControl : UserControl
    {
        public static readonly DependencyProperty ExtraContentProperty =
            DependencyProperty.Register("ExtraContent", typeof(object), typeof(IconControl), new PropertyMetadata(null));

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ElementIcon), typeof(IconControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IconControl() => InitializeComponent();

        public object ExtraContent
        {
            get => GetValue(ExtraContentProperty);
            set => SetValue(ExtraContentProperty, value);
        }

        public ElementIcon Icon
        {
            get => (ElementIcon)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new IconSelectorWindow() { Owner = Window.GetWindow(this) };
            window.ImageSelected += (icon) => Icon = icon;
            window.ShowDialog();
        }
    }
}