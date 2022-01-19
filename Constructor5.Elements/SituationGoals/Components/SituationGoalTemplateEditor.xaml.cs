using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationGoals.Components
{
    [ObjectEditor(typeof(SituationGoalTemplateComponent))]
    public partial class SituationGoalTemplateEditor : UserControl, IObjectEditor
    {
        public SituationGoalTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}