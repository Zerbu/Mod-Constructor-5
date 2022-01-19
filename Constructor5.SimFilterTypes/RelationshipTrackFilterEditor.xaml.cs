using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SimFilterTypes
{
    [ObjectEditor(typeof(RelationshipTrackFilter))]
    public partial class RelationshipTrackFilterEditor : UserControl, IObjectEditor
    {
        public RelationshipTrackFilterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}