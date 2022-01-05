using Constructor5.UI.Dialogs;
using Constructor5.UI.Shared;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.Elements.Broadcasters
{
    [ObjectEditor(typeof(Broadcaster))]
    public partial class BroadcasterEditor : UserControl, IObjectEditor
    {
        public BroadcasterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}