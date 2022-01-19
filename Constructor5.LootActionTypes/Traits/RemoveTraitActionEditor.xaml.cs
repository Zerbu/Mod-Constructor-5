using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Traits
{
    [ObjectEditor(typeof(RemoveTraitAction))]
    public partial class RemoveTraitActionEditor : UserControl, IObjectEditor
    {
        public RemoveTraitActionEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;
    }
}