using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Social;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffMixerInteractionsComponent))]
    public partial class BuffMixerInteractionsEditor : UserControl, IObjectEditor
    {
        public BuffMixerInteractionsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var result = (MixerInteraction)ElementManager.Create(typeof(MixerInteraction), null, true);

            var info = result.GetComponent<InteractionInfoComponent>();
            info.AllowUserDirected = false;
            info.IsHiddenInQueue = true;

            var specialCases = result.GetComponent<MixerInteractionSpecialCasesComponent>();
            specialCases.IsIdle = true;

            return result;
        }
    }
}