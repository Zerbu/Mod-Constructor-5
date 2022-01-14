using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Interactions
{
    [ObjectEditor(typeof(InteractionTimeElapsedCondition))]
    public partial class InteractionTimeElapsedConditionEditor : UserControl, IObjectEditor
    {
        public InteractionTimeElapsedConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}