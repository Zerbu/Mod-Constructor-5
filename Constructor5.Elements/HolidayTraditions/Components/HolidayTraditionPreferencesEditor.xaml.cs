using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [ObjectEditor(typeof(HolidayTraditionPreferencesComponent))]
    public partial class HolidayTraditionPreferencesEditor : UserControl, IObjectEditor
    {
        public HolidayTraditionPreferencesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}