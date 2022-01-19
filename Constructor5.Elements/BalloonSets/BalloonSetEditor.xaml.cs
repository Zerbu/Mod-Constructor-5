using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.BalloonSets
{
    [ObjectEditor(typeof(BalloonSet))]
    public partial class BalloonSetEditor : UserControl, IObjectEditor
    {
        public BalloonSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}