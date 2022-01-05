using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoalSets
{
    [ObjectEditor(typeof(SituationGoalSet), "ElementMini")]
    public partial class SituationGoalSetMiniEditor : UserControl, IObjectEditor
    {
        public SituationGoalSetMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}