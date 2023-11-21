using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.DramaNodes.Components
{
    [ObjectEditor(typeof(DramaNodeInfo))]
    public partial class DramaNodeInfoEditor : UserControl, IObjectEditor
    {
        public DramaNodeInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}