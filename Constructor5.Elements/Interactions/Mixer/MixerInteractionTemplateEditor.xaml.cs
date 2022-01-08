using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Mixer
{
    [ObjectEditor(typeof(MixerInteractionTemplateComponent))]
    public partial class MixerInteractionTemplateEditor : UserControl, IObjectEditor
    {
        public MixerInteractionTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}