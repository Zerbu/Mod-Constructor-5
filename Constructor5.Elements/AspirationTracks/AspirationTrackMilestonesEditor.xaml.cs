using Constructor5.Base.ElementSystem;
using Constructor5.Elements.ObjectiveSets;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationTracks
{
    [ObjectEditor(typeof(AspirationTrackMilestonesComponent))]
    public partial class AspirationTrackMilestonesEditor : UserControl, IObjectEditor
    {
        public AspirationTrackMilestonesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var component = (AspirationTrackMilestonesComponent)DataContext;

            var element = (ObjectiveSet)ElementManager.Create(typeof(ObjectiveSet), null, true);
            element.AddContextModifier(new AssignedAspirationTrackContextModifier
            {
                AspirationTrack = new Reference(component.Element)
            });
            element.AlwaysTrack = false;
            return element;
        }
    }
}