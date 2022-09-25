using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.OddJobs.Components
{
    [ObjectEditor(typeof(OddJobActionsComponent))]
    public partial class OddJobActionsComponentEditor : UserControl, IObjectEditor
    {
        public OddJobActionsComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}