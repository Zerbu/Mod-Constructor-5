using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.RelBits
{
    [ObjectEditor(typeof(RelBit))]
    public partial class RelBitEditor : UserControl, IObjectEditor
    {
        public RelBitEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}