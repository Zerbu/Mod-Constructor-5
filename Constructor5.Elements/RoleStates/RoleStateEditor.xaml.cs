using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.RoleStates
{
    [ObjectEditor(typeof(RoleState))]
    public partial class RoleStateEditor : UserControl, IObjectEditor
    {
        public RoleStateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}