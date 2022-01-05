using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitSpecialCasesComponent))]
    public partial class TraitSpecialCasesEditor : UserControl, IObjectEditor
    {
        public TraitSpecialCasesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
