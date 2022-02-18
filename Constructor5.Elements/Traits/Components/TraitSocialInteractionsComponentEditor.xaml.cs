using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Social.ContextModifiers;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitSocialInteractionsComponent))]
    public partial class TraitSocialInteractionsComponentEditor : UserControl, IObjectEditor
    {
        public TraitSocialInteractionsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var component = (TraitSocialInteractionsComponent)DataContext;

            var result = ElementManager.Create(typeof(SocialInteraction), null, true);
            result.GeneratedLabel = "Custom Interaction";
            result.AddContextModifier(new SIAssociatedTrait
            {
                Trait = new Reference(component.Element)
            });
            return result;
        }
    }
}