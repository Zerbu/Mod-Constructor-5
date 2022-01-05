using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Traits.Components
{
    [ObjectEditor(typeof(TraitBuffReplacementsComponent))]
    public partial class TraitBuffReplacementsEditor : UserControl, IObjectEditor
    {
        public TraitBuffReplacementsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}