using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationJobs
{
    [ObjectEditor(typeof(SituationJob))]
    public partial class SituationJobEditor : UserControl, IObjectEditor
    {
        public SituationJobEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}