using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [ObjectEditor(typeof(SituationGoalInteractionTemplate))]
    public partial class SituationGoalInteractionEditor : UserControl, IObjectEditor
    {
        public SituationGoalInteractionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}