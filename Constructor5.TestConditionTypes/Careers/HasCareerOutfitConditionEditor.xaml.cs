using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Careers
{
    [ObjectEditor(typeof(HasCareerOutfitCondition))]
    public partial class HasCareerOutfitConditionEditor : UserControl, IObjectEditor
    {
        public HasCareerOutfitConditionEditor() => InitializeComponent();

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