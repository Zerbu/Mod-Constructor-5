using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Buffs
{
    [ObjectEditor(typeof(AddBuffAction))]
    public partial class AddBuffActionEditor : UserControl, IObjectEditor
    {
        public AddBuffActionEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;
    }
}
