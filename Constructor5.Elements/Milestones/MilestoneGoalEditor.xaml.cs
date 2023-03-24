using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Milestones
{
    [ObjectEditor(typeof(MilestoneGoal))]
    public partial class MilestoneGoalEditor : UserControl, IObjectEditor
    {
        public MilestoneGoalEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}