using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [ObjectEditor(typeof(BroadcasterLootEffect))]
    public partial class BroadcasterLootEffectEditor : UserControl, IObjectEditor
    {
        public BroadcasterLootEffectEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}