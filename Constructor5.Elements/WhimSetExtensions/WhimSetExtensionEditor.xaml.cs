using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.Elements.Whims;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.WhimSetExtensions
{
    [ObjectEditor(typeof(WhimSetExtension))]
    public partial class WhimSetExtensionEditor : UserControl, IObjectEditor
    {
        public WhimSetExtensionEditor() => InitializeComponent();

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