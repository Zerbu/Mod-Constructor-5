using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.RelBits
{
    [ObjectEditor(typeof(RelBitAction))]
    public partial class RelBitActionBaseEditor : UserControl, IObjectEditor
    {
        public RelBitActionBaseEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}