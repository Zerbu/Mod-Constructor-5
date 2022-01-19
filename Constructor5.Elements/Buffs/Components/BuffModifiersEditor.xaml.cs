using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Buffs.Components;
using Constructor5.Elements.Buffs.Modifiers;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.Components
{
    [ObjectEditor(typeof(BuffModifiersComponent))]
    public partial class BuffModifiersEditor : UserControl, IObjectEditor
    {
        public BuffModifiersEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
