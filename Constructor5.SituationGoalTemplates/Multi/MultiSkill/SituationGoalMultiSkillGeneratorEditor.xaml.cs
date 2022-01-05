using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SituationGoalTemplates.Multi.MultiSkill
{
    [ObjectEditor(typeof(SituationGoalMultiSkillGenerator))]
    public partial class SituationGoalMultiSkillGeneratorEditor : UserControl, IObjectEditor
    {
        public SituationGoalMultiSkillGeneratorEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}