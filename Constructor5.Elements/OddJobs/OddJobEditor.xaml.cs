using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.OddJobs
{
    [ObjectEditor(typeof(OddJob))]
    public partial class OddJobEditor : UserControl, IObjectEditor
    {
        public OddJobEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}