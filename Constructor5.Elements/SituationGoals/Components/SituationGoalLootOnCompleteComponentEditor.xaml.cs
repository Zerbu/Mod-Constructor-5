using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalLootOnCompleteComponent))]
    public partial class SituationGoalLootOnCompleteComponentEditor : UserControl, IObjectEditor
    {
        public SituationGoalLootOnCompleteComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}