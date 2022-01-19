using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Relationships
{
    [ObjectEditor(typeof(RelationshipCondition))]
    public partial class RelationshipConditionEditor : UserControl, IObjectEditor
    {
        public RelationshipConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}