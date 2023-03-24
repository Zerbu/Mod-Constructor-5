using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Milestones
{
    [ObjectEditor(typeof(MilestoneActionsOnComplete))]
    public partial class MilestoneActionsOnCompleteEditor : UserControl, IObjectEditor
    {
        public MilestoneActionsOnCompleteEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}