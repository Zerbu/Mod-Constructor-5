using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationTracks
{
    [ObjectEditor(typeof(AspirationTrackWhimsComponent))]
    public partial class AspirationTrackWhimsEditor : UserControl, IObjectEditor
    {
        public AspirationTrackWhimsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}