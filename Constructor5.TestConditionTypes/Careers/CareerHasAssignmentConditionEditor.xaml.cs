using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Careers
{
    [ObjectEditor(typeof(CareerHasAssignmentCondition))]
    public partial class CareerHasAssignmentConditionEditor : UserControl, IObjectEditor
    {
        public CareerHasAssignmentConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}