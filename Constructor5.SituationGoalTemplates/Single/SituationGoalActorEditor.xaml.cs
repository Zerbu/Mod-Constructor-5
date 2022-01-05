using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [ObjectEditor(typeof(SituationGoalActorTemplate))]
    public partial class SituationGoalActorEditor : UserControl, IObjectEditor
    {
        public SituationGoalActorEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}