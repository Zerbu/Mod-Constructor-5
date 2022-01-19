using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Traits.Components;
using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationTracks
{
    [ObjectEditor(typeof(AspirationTrackInfoComponent))]
    public partial class AspirationTrackInfoEditor : UserControl, IObjectEditor
    {
        public AspirationTrackInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;

        private Element ReferenceControl_CreateElementFunction()
        {
            var result = (Trait)ElementManager.Create(typeof(Trait), null, true);
            var component = result.GetTraitComponent<TraitInfoComponent>();
            component.TraitType = TraitTypes.Aspiration;
            return result;
        }
    }
}