using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalExpirationComponent))]
    public partial class SituationGoalExpirationComponentEditor : UserControl, IObjectEditor
    {
        public SituationGoalExpirationComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}