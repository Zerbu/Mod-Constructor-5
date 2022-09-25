using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Whims
{
    [ObjectEditor(typeof(Whim), "ElementMini")]
    public partial class WhimMiniEditor : UserControl, IObjectEditor
    {
        public WhimMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Element ReferenceListControl_CreateElementFunction()
        {
            var result = (SituationGoal)ElementManager.Create(typeof(SituationGoal), null, true);
            result.AddContextModifier(new WhimGoalContextModifier());
            return result;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var whim = (Whim)DataContext;
            if (whim.Goal.Element != null)
            {
                var goal = (SituationGoal)whim.Goal.Element;
                var goalInfo = goal.GetComponent<SituationGoalInfoComponent>();
                goalInfo.Name.CustomText = LabelTextBox.Text;
            }
        }
    }
}