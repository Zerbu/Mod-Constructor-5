using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.SituationJobs.Components
{
    [ObjectEditor(typeof(SituationJobRewardsComponent))]
    public partial class SituationJobRewardsEditor : UserControl, IObjectEditor
    {
        public SituationJobRewardsEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}