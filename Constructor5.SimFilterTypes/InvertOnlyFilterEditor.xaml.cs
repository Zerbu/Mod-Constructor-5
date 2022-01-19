using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SimFilterTypes
{
    [ObjectEditor(typeof(IsActiveHouseholdFilter))]
    [ObjectEditor(typeof(IsRoommateFilter))]
    public partial class InvertOnlyFilterEditor : UserControl, IObjectEditor
    {
        public InvertOnlyFilterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}