using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.OddJobs.Components
{
    [ObjectEditor(typeof(OddJobInfoComponent))]
    public partial class OddJobInfoComponentEditor : UserControl, IObjectEditor
    {
        public OddJobInfoComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}