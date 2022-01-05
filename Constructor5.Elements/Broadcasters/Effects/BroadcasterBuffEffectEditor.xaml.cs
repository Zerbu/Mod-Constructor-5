using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [ObjectEditor(typeof(BroadcasterBuffEffect))]
    public partial class BroadcasterBuffEffectEditor : UserControl, IObjectEditor
    {
        public BroadcasterBuffEffectEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}