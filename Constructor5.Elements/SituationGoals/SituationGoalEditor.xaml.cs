using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals
{
    [ObjectEditor(typeof(SituationGoal))]
    public partial class SituationGoalEditor : UserControl, IObjectEditor
    {
        public SituationGoalEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}