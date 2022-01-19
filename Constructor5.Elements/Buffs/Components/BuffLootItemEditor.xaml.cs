using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffLootItem))]
    public partial class BuffLootItemEditor : UserControl, IObjectEditor
    {
        public BuffLootItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
