using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Funny
{
    [ObjectEditor(typeof(FunnySITemplate))]
    [ObjectEditor(typeof(FunnyIntroductionTemplate))]
    public partial class FunnySITemplateEditor : UserControl, IObjectEditor
    {
        public FunnySITemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "AssignedInteraction")
            {
                GlobalInteractionCheckBox.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!(DataContext.GetType() == typeof(FunnySITemplate)))
            {
                LootListControl.ItemTypeName = "FunnyIntroductionLootItem";
            }
        }
    }
}