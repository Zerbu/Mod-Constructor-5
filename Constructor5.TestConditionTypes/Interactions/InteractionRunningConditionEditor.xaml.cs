using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Interactions
{
    [ObjectEditor(typeof(InteractionRunningCondition))]
    public partial class InteractionRunningConditionEditor : UserControl, IObjectEditor
    {
        public InteractionRunningConditionEditor() => InitializeComponent();

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