using Constructor5.Elements.Interactions.Shared;
using Constructor5.Elements.Interactions.Social;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Mixer
{
    [ObjectEditor(typeof(MixerInteraction), "ElementMini")]
    public partial class MixerInteractionMiniEditor : UserControl, IObjectEditor
    {
        public static readonly DependencyProperty InfoComponentProperty =
            DependencyProperty.Register("InfoComponent", typeof(InteractionInfoComponent), typeof(MixerInteractionMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty LockOutComponentProperty =
            DependencyProperty.Register("LockOutComponent", typeof(InteractionLockOutComponent), typeof(MixerInteractionMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty TemplateComponentProperty =
                    DependencyProperty.Register("TemplateComponent", typeof(MixerInteractionTemplateComponent), typeof(MixerInteractionMiniEditor), new PropertyMetadata(null));

        public MixerInteractionMiniEditor() => InitializeComponent();

        public InteractionInfoComponent InfoComponent
        {
            get => (InteractionInfoComponent)GetValue(InfoComponentProperty);
            set => SetValue(InfoComponentProperty, value);
        }

        public InteractionLockOutComponent LockOutComponent
        {
            get => (InteractionLockOutComponent)GetValue(LockOutComponentProperty);
            set { SetValue(LockOutComponentProperty, value); }
        }

        public MixerInteractionTemplateComponent TemplateComponent
        {
            get => (MixerInteractionTemplateComponent)GetValue(TemplateComponentProperty);
            set => SetValue(TemplateComponentProperty, value);
        }

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            var interaction = (MixerInteraction)obj;
            InfoComponent = interaction.GetComponent<InteractionInfoComponent>();
            TemplateComponent = interaction.GetComponent<MixerInteractionTemplateComponent>();
            LockOutComponent = interaction.GetComponent<InteractionLockOutComponent>();
        }

        private void EAPresetButton_Click(object sender, RoutedEventArgs e)
        {
            var interaction = (MixerInteraction)DataContext;
            var component = interaction.GetComponent<InteractionLockOutComponent>();

            component.LockOutTime.RestrictLowerBound = true;
            component.LockOutTime.RestrictUpperBound = true;
            component.LockOutTime.LowerBound = 120;
            component.LockOutTime.UpperBound = 480;

            component.InitialLockOutTime.RestrictLowerBound = true;
            component.InitialLockOutTime.RestrictUpperBound = true;
            component.InitialLockOutTime.LowerBound = 240;
            component.InitialLockOutTime.UpperBound = 480;
        }
    }
}