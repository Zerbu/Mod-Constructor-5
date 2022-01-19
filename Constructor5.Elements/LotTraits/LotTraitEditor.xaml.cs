using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.LotTraits
{
    [ObjectEditor(typeof(LotTrait))]
    public partial class LotTraitEditor : UserControl, IObjectEditor
    {
        public LotTraitEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}