using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationJobs.Components
{
    [ObjectEditor(typeof(SituationJobUniformComponent))]
    public partial class SituationJobUniformEditor : UserControl, IObjectEditor
    {
        public SituationJobUniformEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}