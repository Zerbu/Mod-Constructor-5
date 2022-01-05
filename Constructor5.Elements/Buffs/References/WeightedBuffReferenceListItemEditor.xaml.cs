using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Buffs.References
{
    [ObjectEditor(typeof(WeightedBuffReferenceListItem))]
    public partial class WeightedBuffReferenceListItemEditor : UserControl, IObjectEditor
    {
        public WeightedBuffReferenceListItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}