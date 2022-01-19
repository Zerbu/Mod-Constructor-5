using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals
{
    [ObjectEditor(typeof(WeightedGoalReferenceListItem))]
    public partial class WeightedGoalReferenceListItemEditor : UserControl, IObjectEditor
    {
        public WeightedGoalReferenceListItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}