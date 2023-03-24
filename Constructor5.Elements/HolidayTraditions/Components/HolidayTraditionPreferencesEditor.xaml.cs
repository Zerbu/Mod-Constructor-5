using Constructor5.UI.Shared;
using System;
using System.Windows.Controls;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [ObjectEditor(typeof(HolidayTraditionPreferencesComponent))]
    public partial class HolidayTraditionPreferencesEditor : UserControl, IObjectEditor
    {
        public HolidayTraditionPreferencesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        public static Action<HolidayTraditionPreference> AddChildPreference { get; set; }

        private void PresetToddlerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var component = (HolidayTraditionPreferencesComponent)DataContext;
            component.SetToddlerPreferencePreset((HolidayTraditionPreference)ListView.SelectedItem);
        }

        private void PresetChildButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var preference = (HolidayTraditionPreference)ListView.SelectedItem;
            preference.Reason.CustomText = "0x7201CF06 <<< (From Being a Child)";
            preference.Conditions.Clear();
            AddChildPreference.Invoke(preference);
        }

        private void PresetInfantButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var component = (HolidayTraditionPreferencesComponent)DataContext;
            component.SetInfantPreferencePreset((HolidayTraditionPreference)ListView.SelectedItem);
        }
    }
}