using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Situations
{
    [ObjectEditor(typeof(SituationCondition))]
    [ObjectEditor(typeof(SituationConditionForGoals))]
    public partial class SituationConditionEditor : UserControl, IObjectEditor
    {
        public SituationConditionEditor() => InitializeComponent();

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