using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.Elements.Whims;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SimpleWhimSets
{
    [ObjectEditor(typeof(SimpleWhimSet), "ElementMini")]
    public partial class SimpleWhimSetMiniEditor : UserControl, IObjectEditor
    {
        public SimpleWhimSetMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Element ReferenceListControl_CreateElementFunction()
        {
            var result = (Whim)ElementManager.Create(typeof(Whim), null, true);

            var goal = (SituationGoal)ElementManager.Create(typeof(SituationGoal), null, true);
            var component = goal.GetComponent<SituationGoalInfoComponent>();
            component.SetScore = true;
            component.Score = 50;

            result.Goal = new Reference(goal);
            return result;
        }
    }
}