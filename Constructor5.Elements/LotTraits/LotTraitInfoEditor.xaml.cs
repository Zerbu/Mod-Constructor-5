using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.LotTraits
{
    [ObjectEditor(typeof(LotTraitInfoComponent))]
    public partial class LotTraitInfoEditor : UserControl, IObjectEditor
    {
        public LotTraitInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}