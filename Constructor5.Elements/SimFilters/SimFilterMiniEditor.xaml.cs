using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SimFilters
{
    [ObjectEditor(typeof(SimFilter), "ElementMini")]
    public partial class SimFilterMiniEditor : UserControl, IObjectEditor
    {
        public SimFilterMiniEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}