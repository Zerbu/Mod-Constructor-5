using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Interactions.Shared
{
    [ObjectEditor(typeof(InteractionLockOutComponent))]
    public partial class InteractionLockOutEditor : UserControl, IObjectEditor
    {
        public InteractionLockOutEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}