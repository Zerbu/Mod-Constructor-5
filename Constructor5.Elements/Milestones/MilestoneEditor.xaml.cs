using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Milestones
{
    [ObjectEditor(typeof(Milestone))]
    public partial class MilestoneEditor : UserControl, IObjectEditor
    {
        public MilestoneEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}