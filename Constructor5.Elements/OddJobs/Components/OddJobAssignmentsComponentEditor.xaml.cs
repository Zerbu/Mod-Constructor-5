using Constructor5.Base.ElementSystem;
using Constructor5.Elements.ObjectiveSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.OddJobs.Components
{
    [ObjectEditor(typeof(OddJobAssignmentsComponent))]
    public partial class OddJobAssignmentsComponentEditor : UserControl, IObjectEditor
    {
        public OddJobAssignmentsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private Element CreateAssignmentFunction()
        {
            var result = (ObjectiveSet)ElementManager.Create(typeof(ObjectiveSet), null, true);
            result.AddContextModifier(new CareerAssignmentGigContextModifier
            {
            });
            result.AlwaysTrack = false;
            return result;
        }
    }
}