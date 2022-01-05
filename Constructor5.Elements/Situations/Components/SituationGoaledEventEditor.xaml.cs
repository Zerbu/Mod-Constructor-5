using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations.Components
{
    [ObjectEditor(typeof(SituationGoaledEventComponent))]
    public partial class SituationGoaledEventEditor : UserControl, IObjectEditor
    {
        public SituationGoaledEventEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}