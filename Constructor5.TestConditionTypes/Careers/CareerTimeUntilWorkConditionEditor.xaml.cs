using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Careers
{
    [ObjectEditor(typeof(CareerTimeUntilWorkCondition))]
    public partial class CareerTimeUntilWorkConditionEditor : UserControl, IObjectEditor
    {
        public CareerTimeUntilWorkConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}