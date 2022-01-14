using Constructor5.Base.PropertyTypes;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    /// <summary>
    /// Interaction logic for NotificationOrDialogControl.xaml
    /// </summary>
    public partial class NotificationOrDialogControl : UserControl
    {
        public static readonly DependencyProperty CanChangeTypeProperty =
            DependencyProperty.Register("CanChangeType", typeof(bool), typeof(NotificationOrDialogControl), new PropertyMetadata(true));

        public static readonly DependencyProperty NotificationOrDialogProperty =
                    DependencyProperty.Register("NotificationOrDialog", typeof(NotificationOrDialog), typeof(NotificationOrDialogControl), new PropertyMetadata(null));

        public NotificationOrDialogControl() => InitializeComponent();

        public bool CanChangeType
        {
            get => (bool)GetValue(CanChangeTypeProperty);
            set => SetValue(CanChangeTypeProperty, value);
        }

        public NotificationOrDialog NotificationOrDialog
        {
            get => (NotificationOrDialog)GetValue(NotificationOrDialogProperty);
            set => SetValue(NotificationOrDialogProperty, value);
        }
    }
}