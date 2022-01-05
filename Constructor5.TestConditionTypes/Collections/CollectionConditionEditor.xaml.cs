using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Collections
{
    [ObjectEditor(typeof(CollectionCondition))]
    [ObjectEditor(typeof(CollectionSituationGoalCondition))]
    public partial class CollectionConditionEditor : UserControl, IObjectEditor
    {
        public CollectionConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}