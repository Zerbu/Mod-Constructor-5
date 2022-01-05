using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationJobs.Components
{
    [ObjectEditor(typeof(SituationJobInfoComponent))]
    public partial class SituationJobInfoEditor : UserControl, IObjectEditor
    {
        public SituationJobInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}