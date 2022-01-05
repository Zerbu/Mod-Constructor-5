using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Traits
{
    [ObjectEditor(typeof(AddTraitAction))]
    public partial class AddTraitActionEditor : UserControl, IObjectEditor
    {
        public AddTraitActionEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;
    }
}