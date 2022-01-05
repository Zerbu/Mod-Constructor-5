using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Careers
{
    [ObjectEditor(typeof(CareerDaysWorkedCondition))]
    public partial class CareerDaysWorkedConditionEditor : UserControl, IObjectEditor
    {
        public CareerDaysWorkedConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}