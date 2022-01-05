using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Collections
{
    [ObjectEditor(typeof(CollectedSingleItemCondition))]
    public partial class CollectedSingleItemConditionEditor : UserControl, IObjectEditor
    {
        public CollectedSingleItemConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}