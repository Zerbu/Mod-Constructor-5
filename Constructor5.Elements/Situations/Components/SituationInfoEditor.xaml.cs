using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations.Components
{
    [ObjectEditor(typeof(SituationInfoComponent))]
    public partial class SituationInfoEditor : UserControl, IObjectEditor
    {
        public SituationInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}