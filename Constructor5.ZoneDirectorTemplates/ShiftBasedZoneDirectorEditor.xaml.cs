using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.ZoneDirectorTemplates
{
    [ObjectEditor(typeof(ShiftBasedZoneDirector))]
    public partial class ShiftBasedZoneDirectorEditor : UserControl, IObjectEditor
    {
        public ShiftBasedZoneDirectorEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}