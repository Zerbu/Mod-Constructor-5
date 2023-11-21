using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.DramaNodes
{
    [ObjectEditor(typeof(ScheduleDramaNode))]
    public partial class ScheduleDramaNodeEditor : UserControl, IObjectEditor
    {
        public ScheduleDramaNodeEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}