using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.RoleStates
{
    [ObjectEditor(typeof(RoleState), "ElementMini")]
    public partial class RoleStateMiniEditor : UserControl, IObjectEditor
    {
        public RoleStateMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}