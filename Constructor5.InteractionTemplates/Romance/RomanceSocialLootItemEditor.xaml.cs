using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Romance
{
    [ObjectEditor(typeof(RomanceSocialLootItem))]
    public partial class RomanceSocialLootItemEditor : UserControl, IObjectEditor
    {
        public RomanceSocialLootItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}