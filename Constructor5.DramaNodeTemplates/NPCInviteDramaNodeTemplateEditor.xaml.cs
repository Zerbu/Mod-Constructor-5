using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.DramaNodeTemplates
{
    [ObjectEditor(typeof(NPCInviteDramaNodeTemplate))]
    public partial class NPCInviteDramaNodeTemplateEditor : UserControl, IObjectEditor
    {
        public NPCInviteDramaNodeTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}