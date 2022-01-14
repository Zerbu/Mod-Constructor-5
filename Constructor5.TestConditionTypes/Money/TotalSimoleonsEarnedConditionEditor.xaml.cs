using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Money
{
    [ObjectEditor(typeof(TotalSimoleonsEarnedCondition))]
    public partial class TotalSimoleonsEarnedConditionEditor : UserControl, IObjectEditor
    {
        public TotalSimoleonsEarnedConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}