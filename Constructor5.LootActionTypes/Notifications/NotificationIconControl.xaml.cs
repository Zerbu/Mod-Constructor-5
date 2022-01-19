using System.Windows;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Notifications
{
    /// <summary>
    /// Interaction logic for NotificationIconControl.xaml
    /// </summary>
    public partial class NotificationIconControl : UserControl
    {
        public NotificationIconControl() => InitializeComponent();

        public NotificationIcon Icon
        {
            get => (NotificationIcon)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(NotificationIcon), typeof(NotificationIconControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
