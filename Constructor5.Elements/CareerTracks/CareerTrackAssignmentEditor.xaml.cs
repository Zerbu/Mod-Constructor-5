using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CareerTracks
{
    [ObjectEditor(typeof(CareerTrackAssignment))]
    public partial class CareerTrackAssignmentEditor : UserControl, IObjectEditor
    {
        public CareerTrackAssignmentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}