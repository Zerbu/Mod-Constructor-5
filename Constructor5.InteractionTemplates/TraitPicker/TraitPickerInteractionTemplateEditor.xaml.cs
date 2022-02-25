using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.InteractionTemplates.TraitPicker
{
    [ObjectEditor(typeof(TraitPickerInteractionTemplate))]
    public partial class TraitPickerInteractionTemplateEditor : UserControl, IObjectEditor
    {
        public TraitPickerInteractionTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}