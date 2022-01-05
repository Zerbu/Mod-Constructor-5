using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.AspirationTracks
{
    [ObjectEditor(typeof(AspirationTrackInfoComponent))]
    public partial class AspirationTrackInfoEditor : UserControl, IObjectEditor
    {
        public AspirationTrackInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}