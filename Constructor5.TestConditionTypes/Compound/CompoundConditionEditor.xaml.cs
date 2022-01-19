using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Compound
{
    [ObjectEditor(typeof(CompoundCondition))]
    public partial class CompoundConditionEditor : UserControl, IObjectEditor
    {
        public CompoundConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}