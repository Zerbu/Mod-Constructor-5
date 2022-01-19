using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Locations
{
    [ObjectEditor(typeof(LocationCondition))]
    [ObjectEditor(typeof(LocationObjectiveCondition))]
    public partial class LocationConditionEditor : UserControl, IObjectEditor
    {
        public LocationConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}