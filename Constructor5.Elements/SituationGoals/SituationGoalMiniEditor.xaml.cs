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
        }
    }
}