using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalPreConditionsComponentEditor))]
    public partial class SituationGoalPreConditionsComponentEditor : UserControl, IObjectEditor
    {
        public SituationGoalPreConditionsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}