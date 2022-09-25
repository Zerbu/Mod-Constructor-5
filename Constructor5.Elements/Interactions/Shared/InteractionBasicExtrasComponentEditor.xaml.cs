using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Shared
{
    [ObjectEditor(typeof(InteractionBasicExtrasComponent))]
    public partial class InteractionBasicExtrasComponentEditor : UserControl, IObjectEditor
    {
        public InteractionBasicExtrasComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}