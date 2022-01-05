using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Buffs
{
    [ObjectEditor(typeof(RemoveBuffsAction))]
    public partial class RemoveBuffsActionEditor : UserControl, IObjectEditor
    {
        public RemoveBuffsActionEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;
    }
}