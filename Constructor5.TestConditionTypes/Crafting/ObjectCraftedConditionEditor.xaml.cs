using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Crafting
{
    [ObjectEditor(typeof(ObjectCraftedCondition))]
    public partial class ObjectCraftedConditionEditor : UserControl, IObjectEditor
    {
        public ObjectCraftedConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}