using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalPostConditionsComponent))]
    public partial class SituationGoalPostConditionsComponentEditor : UserControl, IObjectEditor
    {
        public SituationGoalPostConditionsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}