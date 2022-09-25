using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SimpleWhimSets
{
    [ObjectEditor(typeof(SimpleWhimSet))]
    public partial class SimpleWhimSetEditor : UserControl, IObjectEditor
    {
        public SimpleWhimSetEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}