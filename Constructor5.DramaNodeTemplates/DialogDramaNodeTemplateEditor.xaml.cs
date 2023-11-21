using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.DramaNodeTemplates
{
    [ObjectEditor(typeof(DialogDramaNodeTemplate))]
    public partial class DialogDramaNodeTemplateEditor : UserControl, IObjectEditor
    {
        public DialogDramaNodeTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}