using Constructor5.Base.ElementSystem;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationTracks
{
    [ObjectEditor(typeof(AspirationTrackWhimsComponent))]
    public partial class AspirationTrackWhimsEditor : UserControl, IObjectEditor
    {
        public AspirationTrackWhimsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var result = (SituationGoal)ElementManager.Create(typeof(SituationGoal), null, true);
            var component = result.GetComponent<SituationGoalInfoComponent>();
            component.SetScore = true;
            component.Score = 50;
            return result;
        }
    }
}