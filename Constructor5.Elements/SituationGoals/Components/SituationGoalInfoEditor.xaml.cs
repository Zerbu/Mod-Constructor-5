using Constructor5.Base.ElementSystem;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalInfoComponent))]
    public partial class SituationGoalInfoEditor : UserControl, IObjectEditor
    {
        public SituationGoalInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;

            var contextModifier = ((SituationGoalInfoComponent)obj).Element.GetContextModifier<HolidayTraditionContextModifier>();
            if (contextModifier == null)
            {
                return;
            }

            SetCooldownCheckBox.Visibility = System.Windows.Visibility.Collapsed;
            SetScoreCheckBox.Visibility = System.Windows.Visibility.Collapsed;
            HolidayTraditionWarning.Visibility = System.Windows.Visibility.Visible;
            RoleTagsExpander.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}