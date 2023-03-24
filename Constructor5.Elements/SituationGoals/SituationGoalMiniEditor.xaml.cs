using Constructor5.Elements.Milestones;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals
{
    [ObjectEditor(typeof(SituationGoal), "ElementMini")]
    public partial class SituationGoalMiniEditor : UserControl, IObjectEditor
    {
        public static readonly DependencyProperty SituationGoalInfoComponentProperty =
            DependencyProperty.Register("SituationGoalInfoComponent", typeof(SituationGoalInfoComponent), typeof(SituationGoalMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty SituationGoalPostConditionsComponentProperty =
            DependencyProperty.Register("SituationGoalPostConditionsComponent", typeof(SituationGoalPostConditionsComponent), typeof(SituationGoalMiniEditor), new PropertyMetadata(null));

        public static readonly DependencyProperty SituationGoalTemplateComponentProperty =
            DependencyProperty.Register("SituationGoalTemplateComponent", typeof(SituationGoalTemplateComponent), typeof(SituationGoalMiniEditor), new PropertyMetadata(null));

        public SituationGoalMiniEditor() => InitializeComponent();

        public SituationGoalInfoComponent SituationGoalInfoComponent
        {
            get => (SituationGoalInfoComponent)GetValue(SituationGoalInfoComponentProperty);
            set => SetValue(SituationGoalInfoComponentProperty, value);
        }

        public SituationGoalPostConditionsComponent SituationGoalPostConditionsComponent
        {
            get => (SituationGoalPostConditionsComponent)GetValue(SituationGoalPostConditionsComponentProperty);
            set => SetValue(SituationGoalPostConditionsComponentProperty, value);
        }

        public SituationGoalTemplateComponent SituationGoalTemplateComponent
        {
            get => (SituationGoalTemplateComponent)GetValue(SituationGoalTemplateComponentProperty);
            set => SetValue(SituationGoalTemplateComponentProperty, value);
        }



        public SituationGoalPreConditionsComponent SituationGoalPreConditionsComponent
        {
            get { return (SituationGoalPreConditionsComponent)GetValue(SituationGoalPreConditionsComponentProperty); }
            set { SetValue(SituationGoalPreConditionsComponentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SituationGoalPreConditionsComponent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SituationGoalPreConditionsComponentProperty =
            DependencyProperty.Register("SituationGoalPreConditionsComponent", typeof(SituationGoalPreConditionsComponent), typeof(SituationGoalMiniEditor), new PropertyMetadata(null));



        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            ((IObjectEditor)SituationGoalInfoEditor).SetObject(((SituationGoal)obj).GetComponent<SituationGoalInfoComponent>(), null);
            SituationGoalTemplateComponent = ((SituationGoal)obj).GetComponent<SituationGoalTemplateComponent>();
            SituationGoalPostConditionsComponent = ((SituationGoal)obj).GetComponent<SituationGoalPostConditionsComponent>();
            if (tag == "Whim")
            {
                SituationGoalInfoEditor.RoleTagsExpander.Visibility = Visibility.Collapsed;
                SituationGoalInfoEditor.SetScoreCheckBox.Visibility = Visibility.Collapsed;
            }

            var milestoneContext = ((SituationGoal)obj).GetContextModifier<MilestoneContextModifier>();
            if (milestoneContext != null)
            {
                SituationGoalInfoEditor.RoleTagsExpander.Visibility = Visibility.Collapsed;
                SituationGoalInfoEditor.SetScoreCheckBox.Visibility = Visibility.Collapsed;
                SituationGoalInfoEditor.SetCooldownCheckBox.Visibility = Visibility.Collapsed;
                SituationGoalInfoEditor.IsHiddenCheckBox.Visibility = Visibility.Collapsed;
                SituationGoalInfoEditor.ShowLocationCheckBox.Visibility = Visibility.Visible;
                SituationGoalInfoEditor.ContextlessDescriptionTextBox.Visibility = Visibility.Visible;
            }

            SituationGoalPreConditionsComponent = ((SituationGoal)obj).GetComponent<SituationGoalPreConditionsComponent>();
        }
    }
}