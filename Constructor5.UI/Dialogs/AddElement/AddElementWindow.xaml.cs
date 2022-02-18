using Constructor5.Base;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.LocalizationSystem;
using Constructor5.Core;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Constructor5.UI.Dialogs.AddElement
{
    /// <summary>
    /// Interaction logic for AddElementWindow.xaml
    /// </summary>
    public partial class AddElementWindow : Window, IOnElementCreated
    {
        public AddElementWindow()
        {
            InitializeComponent();
            Hooks.RegisterClass(this);
            RefreshElements();
            ShowAllCheckBox.IsChecked = ProgramSettings.ShowAllSettingEnabled;
        }

        private void RefreshElements()
            => ElementTypesControl.ItemsSource = ContentRegistry.GetAll<ElementTypeData>("ElementTypes")
            .Where(x => x.CanBeCreatedByUser && (x.IsRootType || ShowAllCheckBox.IsChecked == true))
            .OrderBy(x => x.Label);

        void IOnElementCreated.OnElementCreated(Element element)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                return;
            }
            Close();
        }

        private bool UserHasChangedElementName { get; set; }

        private void ElementNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => UserHasChangedElementName = true;

        private void ElementTypesControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UserHasChangedElementName)
            {
                return;
            }

            ElementNameTextBox.Text = TextStringManager.Get(((ElementTypeData)ElementTypesControl.SelectedItem)?.Label);
            UserHasChangedElementName = false;
        }

        private void ShowAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            RefreshElements();
            ProgramSettings.ShowAllSettingEnabled = ShowAllCheckBox.IsChecked == true;
        }
    }
}