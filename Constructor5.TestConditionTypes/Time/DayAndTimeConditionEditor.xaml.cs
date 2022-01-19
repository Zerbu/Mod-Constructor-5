using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Time
{
    [ObjectEditor(typeof(DayAndTimeCondition))]
    public partial class DayAndTimeConditionEditor : UserControl, IObjectEditor
    {
        public DayAndTimeConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}