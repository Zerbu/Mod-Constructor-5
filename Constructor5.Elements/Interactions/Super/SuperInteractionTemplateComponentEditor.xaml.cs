using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Super
{
    [ObjectEditor(typeof(SuperInteractionTemplateComponent))]
    public partial class SuperInteractionTemplateComponentEditor : UserControl, IObjectEditor
    {
        public SuperInteractionTemplateComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}