using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Statistics
{
    [ObjectEditor(typeof(SkillInUseCondition))]
    public partial class SkillInUseConditionEditor : UserControl, IObjectEditor
    {
        public SkillInUseConditionEditor() => InitializeComponent();

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