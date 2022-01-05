using Constructor5.Base.ElementSystem;
using Constructor5.Elements.LootActionSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffLootComponent))]
    public partial class BuffLootEditor : UserControl, IObjectEditor
    {
        public BuffLootEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
