using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Romance
{
    [ObjectEditor(typeof(RomanceSITemplate))]
    [ObjectEditor(typeof(FlirtyIntroductionTemplate))]
    public partial class RomanceSITemplateEditor : UserControl, IObjectEditor
    {
        public RomanceSITemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "AssignedInteraction")
            {
                GlobalInteractionCheckBox.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!(DataContext.GetType() == typeof(RomanceSITemplate)))
            {
                LootListControl.ItemTypeName = "ReferenceListItem";
                FailureAnimationControl.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}