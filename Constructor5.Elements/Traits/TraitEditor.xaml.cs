using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits
{
    [ObjectEditor(typeof(Trait))]
    public partial class TraitEditor : UserControl, IObjectEditor
    {
        public TraitEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
