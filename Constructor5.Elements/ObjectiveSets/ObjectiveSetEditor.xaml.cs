using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Objectives;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.ObjectiveSets
{
    [ObjectEditor(typeof(ObjectiveSet))]
    public partial class ObjectiveSetEditor : UserControl, IObjectEditor
    {
        public ObjectiveSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceListControl_CreateElementFunction()
        {
            var component = (ObjectiveSet)DataContext;

            var element = (Objective)ElementManager.Create(typeof(Objective), null, true);
            element.AlwaysTrack = component.GetContextModifier<AssignedAspirationTrackContextModifier>() == null;
            return element;
        }
    }
}