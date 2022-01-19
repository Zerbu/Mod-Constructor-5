using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [ObjectEditor(typeof(HolidayTraditionBuffsComponent))]
    public partial class HolidayTraditionBuffsEditor : UserControl, IObjectEditor
    {
        public HolidayTraditionBuffsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}