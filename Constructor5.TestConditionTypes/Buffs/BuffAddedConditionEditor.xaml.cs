using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Buffs
{
    [ObjectEditor(typeof(BuffAddedCondition))]
    public partial class BuffAddedConditionEditor : UserControl, IObjectEditor
    {
        public BuffAddedConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}