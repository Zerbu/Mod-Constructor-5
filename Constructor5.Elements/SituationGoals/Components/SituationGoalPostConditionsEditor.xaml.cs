using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalPostConditionsComponent))]
    public partial class SituationGoalPostConditionsEditor : UserControl, IObjectEditor
    {
        public SituationGoalPostConditionsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}