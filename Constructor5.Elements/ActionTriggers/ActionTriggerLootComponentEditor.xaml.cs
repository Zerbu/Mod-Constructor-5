using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ActionTriggers
{
    [ObjectEditor(typeof(ActionTriggerLootComponent))]
    public partial class ActionTriggerLootComponentEditor : UserControl, IObjectEditor
    {
        public ActionTriggerLootComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}