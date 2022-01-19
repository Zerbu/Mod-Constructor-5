using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Situations.Components
{
    [ObjectEditor(typeof(SituationVenuesComponent))]
    public partial class SituationVenuesEditor : UserControl, IObjectEditor
    {
        public SituationVenuesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}