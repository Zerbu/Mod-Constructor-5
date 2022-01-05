using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Mixer
{
    [ObjectEditor(typeof(MixerInteractionSpecialCasesComponent))]
    public partial class MixerInteractionSpecialCasesEditor : UserControl, IObjectEditor
    {
        public MixerInteractionSpecialCasesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}