using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.HolidayTraditions
{
    [ObjectEditor(typeof(HolidayTradition))]
    public partial class HolidayTraditionEditor : UserControl, IObjectEditor
    {
        public HolidayTraditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}