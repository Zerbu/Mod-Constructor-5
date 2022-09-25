using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ActionTriggers
{
    [ObjectEditor(typeof(ActionTriggerInfoComponent))]
    public partial class ActionTriggerInfoComponentEditor : UserControl, IObjectEditor
    {
        public ActionTriggerInfoComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}