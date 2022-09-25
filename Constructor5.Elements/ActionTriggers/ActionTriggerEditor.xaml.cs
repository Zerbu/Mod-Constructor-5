using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ActionTriggers
{
    [ObjectEditor(typeof(ActionTrigger))]
    public partial class ActionTriggerEditor : UserControl, IObjectEditor
    {
        public ActionTriggerEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}