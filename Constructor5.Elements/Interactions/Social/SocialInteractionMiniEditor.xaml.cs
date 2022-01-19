using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Social
{
    [ObjectEditor(typeof(SocialInteraction), "ElementMini")]
    public partial class SocialInteractionMiniEditor : UserControl, IObjectEditor
    {
        public static readonly DependencyProperty SIInfoComponentProperty =
            DependencyProperty.Register("SIInfoComponent", typeof(InteractionInfoComponent), typeof(SocialInteractionMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty SITemplateComponentProperty =
            DependencyProperty.Register("SITemplateComponent", typeof(SocialInteractionTemplateComponent), typeof(SocialInteractionMiniEditor), new PropertyMetadata(null));

        public SocialInteractionMiniEditor() => InitializeComponent();

        public InteractionInfoComponent SIInfoComponent
        {
            get => (InteractionInfoComponent)GetValue(SIInfoComponentProperty);
            set => SetValue(SIInfoComponentProperty, value);
        }

        public SocialInteractionTemplateComponent SITemplateComponent
        {
            get => (SocialInteractionTemplateComponent)GetValue(SITemplateComponentProperty);
            set => SetValue(SITemplateComponentProperty, value);
        }

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            var interaction = (SocialInteraction)obj;
            SIInfoComponent = interaction.GetComponent<InteractionInfoComponent>();
            SITemplateComponent = interaction.GetComponent<SocialInteractionTemplateComponent>();
        }
    }
}