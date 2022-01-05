using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoalSets
{
    [ObjectEditor(typeof(SituationGoalSet))]
    public partial class SituationGoalSetEditor : UserControl, IObjectEditor
    {
        public SituationGoalSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}