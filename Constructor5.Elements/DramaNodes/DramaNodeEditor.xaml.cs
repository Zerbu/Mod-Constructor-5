using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.DramaNodes
{
    [ObjectEditor(typeof(DramaNode))]
    public partial class DramaNodeEditor : UserControl, IObjectEditor
    {
        public DramaNodeEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}