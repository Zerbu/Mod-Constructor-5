using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Interactions
{
    [ObjectEditor(typeof(ObjectiveInteractionCondition))]
    public partial class ObjectiveInteractionConditionEditor : UserControl, IObjectEditor
    {
        public ObjectiveInteractionConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}