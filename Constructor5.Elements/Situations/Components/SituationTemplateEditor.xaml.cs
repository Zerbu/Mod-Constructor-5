using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations.Components
{
    [ObjectEditor(typeof(SituationTemplateComponent))]
    public partial class SituationTemplateEditor : UserControl, IObjectEditor
    {
        public SituationTemplateEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}