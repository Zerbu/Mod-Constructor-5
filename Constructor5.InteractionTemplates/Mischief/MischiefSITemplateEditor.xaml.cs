using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Mischief
{
    [ObjectEditor(typeof(MischiefSITemplate))]
    public partial class MischiefSITemplateEditor : UserControl, IObjectEditor
    {
        public MischiefSITemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
            if (tag == "AssignedInteraction")
            {
                GlobalInteractionCheckBox.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!(DataContext.GetType() == typeof(MischiefSITemplate)))
            {
                LootListControl.ItemTypeName = "ReferenceListItem";
            }
        }
    }
}