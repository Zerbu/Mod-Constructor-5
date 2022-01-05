using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Statistics
{
    [ObjectEditor(typeof(StatisticCondition))]
    public partial class StatisticConditionEditor : UserControl, IObjectEditor
    {
        public StatisticConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}