using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [ObjectEditor(typeof(HolidayTraditionGoalComponent))]
    public partial class HolidayTraditionGoalEditor : UserControl, IObjectEditor
    {
        public HolidayTraditionGoalEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}