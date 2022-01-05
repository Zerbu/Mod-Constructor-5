using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Mixer
{
    [ObjectEditor(typeof(MixerInteraction))]
    public partial class MixerInteractionEditor : UserControl, IObjectEditor
    {
        public MixerInteractionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}