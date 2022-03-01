using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Mean
{
    [ObjectEditor(typeof(MeanSITemplate))]
    [ObjectEditor(typeof(MeanIntroductionTemplate))]
    public partial class MeanSITemplateEditor : UserControl, IObjectEditor
    {
        public MeanSITemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "AssignedInteraction")
            {
                GlobalInteractionCheckBox.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!(DataContext.GetType() == typeof(MeanSITemplate)))
            {
                LootListControl.ItemTypeName = "ReferenceListItem";
                FailureAnimationControl.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}