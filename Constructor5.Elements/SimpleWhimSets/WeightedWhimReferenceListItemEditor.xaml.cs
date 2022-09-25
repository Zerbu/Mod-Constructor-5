using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SimpleWhimSets
{
    [ObjectEditor(typeof(WeightedWhimReferenceListItem))]
    public partial class WeightedWhimReferenceListItemEditor : UserControl, IObjectEditor
    {
        public WeightedWhimReferenceListItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}