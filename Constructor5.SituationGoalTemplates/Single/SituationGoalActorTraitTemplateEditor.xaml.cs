using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationGoalTemplates.Single
{
    [ObjectEditor(typeof(SituationGoalActorTraitTemplate))]
    public partial class SituationGoalActorTraitTemplateEditor : UserControl, IObjectEditor
    {
        public SituationGoalActorTraitTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}