using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationGoalTemplates.Single
{
    [ObjectEditor(typeof(SituationGoalRelationshipChangedTemplate))]
    public partial class SituationGoalRelationshipChangedEditor : UserControl, IObjectEditor
    {
        public SituationGoalRelationshipChangedEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}