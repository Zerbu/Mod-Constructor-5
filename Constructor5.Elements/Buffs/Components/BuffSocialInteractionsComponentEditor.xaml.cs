using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Social.ContextModifiers;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffSocialInteractionsComponent))]
    public partial class BuffSocialInteractionsComponentEditor : UserControl, IObjectEditor
    {
        public BuffSocialInteractionsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var component = (BuffSocialInteractionsComponent)DataContext;

            var result = ElementManager.Create(typeof(SocialInteraction), null, true);
            result.GeneratedLabel = "Custom Interaction";
            result.AddContextModifier(new SIAssociatedBuff
            {
                Buff = new Reference(component.Element)
            });
            return result;
        }
    }
}