using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Super
{
    [ObjectEditor(typeof(SuperInteraction))]
    public partial class SuperInteractionEditor : UserControl, IObjectEditor
    {
        public SuperInteractionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}