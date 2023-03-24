using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Milestones
{
    [ObjectEditor(typeof(MilestoneDisplayWhenNotUnlocked))]
    public partial class MilestoneDisplayWhenNotUnlockedEditor : UserControl, IObjectEditor
    {
        public MilestoneDisplayWhenNotUnlockedEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}