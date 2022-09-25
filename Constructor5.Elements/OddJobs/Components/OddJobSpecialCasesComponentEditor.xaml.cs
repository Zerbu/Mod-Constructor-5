using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.OddJobs.Components
{
    [ObjectEditor(typeof(OddJobSpecialCasesComponent))]
    public partial class OddJobSpecialCasesComponentEditor : UserControl, IObjectEditor
    {
        public OddJobSpecialCasesComponentEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}