using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Social;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.UI.Interactions.Social
{
    /// <summary>
    /// Interaction logic for SocialInteractionTemplateEditor.xaml
    /// </summary>
    [ObjectEditor(typeof(SocialInteractionTemplateComponent))]
    public partial class InteractionTemplateEditor : UserControl, IObjectEditor
    {
        public InteractionTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            SetRegistryType(obj, SelectableObjectControl);
        }

        private void SetRegistryType(object obj, SelectableObjectControl selectableObjectControl)
        {
            var element = ((SocialInteractionTemplateComponent)obj).Element;

            if (element is MixerInteraction)
            {
                selectableObjectControl.TypeRegistryCategory = "MixerInteractionTemplates";
            }
        }
    }
}