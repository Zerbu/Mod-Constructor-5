using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Friendly
{
    [ObjectEditor(typeof(FriendlySITemplate))]
    [ObjectEditor(typeof(FriendlyIntroductionTemplate))]
    public partial class FriendlySITemplateEditor : UserControl, IObjectEditor
    {
        public FriendlySITemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "AssignedInteraction")
            {
                GlobalInteractionCheckBox.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!(DataContext.GetType() == typeof(FriendlySITemplate)))
            {
                LootListControl.ItemTypeName = "ReferenceListItem";
                FailureAnimationControl.Visibility = System.Windows.Visibility.Collapsed;
                SuccessTargetAnimationControl.Visibility = System.Windows.Visibility.Collapsed;
                FailureTargetAnimationControl.Visibility = System.Windows.Visibility.Collapsed;
                AdvancedTab.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}