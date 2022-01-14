using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.SimFilterTypes
{
    [ObjectEditor(typeof(GenderFilter))]
    public partial class GenderFilterEditor : UserControl, IObjectEditor
    {
        public GenderFilterEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}