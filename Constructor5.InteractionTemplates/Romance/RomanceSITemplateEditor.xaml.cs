using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Romance
{
    [ObjectEditor(typeof(RomanceSITemplate))]
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
        }
    }
}