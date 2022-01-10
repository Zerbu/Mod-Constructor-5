using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SimFilterTypes
{
    [ObjectEditor(typeof(RelationshipBitFilter))]
    public partial class RelationshipBitFilterEditor : UserControl, IObjectEditor
    {
        public RelationshipBitFilterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}