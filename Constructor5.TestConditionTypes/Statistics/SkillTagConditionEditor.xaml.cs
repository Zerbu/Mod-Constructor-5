using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Statistics
{
    [ObjectEditor(typeof(SkillTagCondition))]
    public partial class SkillTagConditionEditor : UserControl, IObjectEditor
    {
        public SkillTagConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "NoParticipant")
            {
                ParticipantField.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}