using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.UI.Buffs
{
    [ObjectEditor(typeof(Buff))]
    public partial class BuffEditor : UserControl, IObjectEditor
    {
        public BuffEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
