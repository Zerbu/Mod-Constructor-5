using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.OddJobs.Components
{
    [ObjectEditor(typeof(OddJobActionsItem))]
    public partial class OddJobActionsItemEditor : UserControl, IObjectEditor
    {
        public OddJobActionsItemEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}