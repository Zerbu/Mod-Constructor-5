using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.Phone
{
    [ObjectEditor(typeof(PhoneTemplate))]
    public partial class PhoneTemplateEditor : UserControl, IObjectEditor
    {
        public PhoneTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}