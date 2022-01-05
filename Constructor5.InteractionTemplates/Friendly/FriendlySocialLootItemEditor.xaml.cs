using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Friendly
{
    [ObjectEditor(typeof(FriendlySocialLootItem))]
    public partial class FriendlySocialLootItemEditor : UserControl, IObjectEditor
    {
        public FriendlySocialLootItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}