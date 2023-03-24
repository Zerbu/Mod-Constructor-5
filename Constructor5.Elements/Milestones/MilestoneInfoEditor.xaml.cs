using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Milestones
{
    [ObjectEditor(typeof(MilestoneInfo))]
    public partial class MilestoneInfoEditor : UserControl, IObjectEditor
    {
        public MilestoneInfoEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}