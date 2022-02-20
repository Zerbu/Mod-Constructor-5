using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Shared
{
    [ObjectEditor(typeof(InteractionAddToObjectComponent))]
    public partial class InteractionAddToObjectComponentEditor : UserControl, IObjectEditor
    {
        public InteractionAddToObjectComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}