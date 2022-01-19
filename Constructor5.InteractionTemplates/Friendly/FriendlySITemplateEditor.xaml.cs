using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Friendly
{
    [ObjectEditor(typeof(FriendlySITemplate))]
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
        }
    }
}