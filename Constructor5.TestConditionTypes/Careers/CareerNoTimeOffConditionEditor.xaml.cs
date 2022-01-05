using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Careers
{
    [ObjectEditor(typeof(CareerNoTimeOffCondition))]
    public partial class CareerNoTimeOffConditionEditor : UserControl, IObjectEditor
    {
        public CareerNoTimeOffConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}