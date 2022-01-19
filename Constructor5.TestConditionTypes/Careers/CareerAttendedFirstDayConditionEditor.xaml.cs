using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Careers
{
    [ObjectEditor(typeof(CareerAttendedFirstDayCondition))]
    public partial class CareerAttendedFirstDayConditionEditor : UserControl, IObjectEditor
    {
        public CareerAttendedFirstDayConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}