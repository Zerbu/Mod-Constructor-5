using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [ObjectEditor(typeof(BroadcasterSelfBuffEffect))]
    public partial class BroadcasterSelfBuffEffectEditor : UserControl, IObjectEditor
    {
        public BroadcasterSelfBuffEffectEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}