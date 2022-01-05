using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SimFilters
{
    [ObjectEditor(typeof(SimFilter))]
    public partial class SimFilterEditor : UserControl, IObjectEditor
    {
        public SimFilterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}