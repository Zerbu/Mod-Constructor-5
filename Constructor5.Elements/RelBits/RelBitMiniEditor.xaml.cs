using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.RelBits
{
    [ObjectEditor(typeof(RelBit), "ElementMini")]
    public partial class RelBitMiniEditor : UserControl, IObjectEditor
    {
        public RelBitMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}