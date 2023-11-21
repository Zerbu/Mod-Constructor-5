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

        private void PresetDiscoverTraitButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationOrDialog.Title.CustomText = "0x205AAE38 <<< New Personality Trait";
            NotificationOrDialog.HasLeftIcon = true;
            NotificationOrDialog.YesNoLeftIconText.CustomText = "NAME OF TRAIT BEING DISCOVERED";
            NotificationOrDialog.HasMiddleIcon = false;
            NotificationOrDialog.HasRightIcon = false;
            NotificationOrDialog.RequireSelfDiscovery = true;

            HasLeftIconCheckBox.IsChecked = true;
            HasMiddleIconCheckBox.IsChecked = true;
            HasRightIconCheckBox.IsChecked = true;
            RequireSelfDiscoveryCheckBox.IsChecked = true;
        }

        private void PresetDiscoverTraitSwapButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationOrDialog.Title.CustomText = "0x205AAE38 <<< New Personality Trait";
            NotificationOrDialog.HasLeftIcon = true;
            NotificationOrDialog.YesNoLeftIconText.CustomText = "NAME OF TRAIT BEING DISCOVERED";
            NotificationOrDialog.HasMiddleIcon = true;
            NotificationOrDialog.YesNoMiddleIcon.Text = "2f7d0004:00000000:944aa44ac60e672c <<< Swap Icon";
            NotificationOrDialog.YesNoMiddleIconText.CustomText = "";
            NotificationOrDialog.HasRightIcon = true;
            NotificationOrDialog.YesNoRightIconText.CustomText = "NAME OF TRAIT BEING REPLACED";
            NotificationOrDialog.RequireSelfDiscovery = true;

            HasLeftIconCheckBox.IsChecked = true;
            HasMiddleIconCheckBox.IsChecked = true;
            HasRightIconCheckBox.IsChecked = true;
            RequireSelfDiscoveryCheckBox.IsChecked = true;
        }
    }
}