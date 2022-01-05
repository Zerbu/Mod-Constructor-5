using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [ObjectEditor(typeof(BroadcasterSelfLootEffect))]
    public partial class BroadcasterSelfLootEffectEditor : UserControl, IObjectEditor
    {
        public BroadcasterSelfLootEffectEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}