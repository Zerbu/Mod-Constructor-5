using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitSetupComponent))]
    public partial class TraitSetupEditor : UserControl, IObjectEditor
    {
        public TraitSetupEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}