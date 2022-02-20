using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Immediate
{
    [ObjectEditor(typeof(ImmediateInteractionTemplate))]
    public partial class ImmediateInteractionTemplateEditor : UserControl, IObjectEditor
    {
        public ImmediateInteractionTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}