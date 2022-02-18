using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Statistics
{
    [ObjectEditor(typeof(SkillCondition))]
    public partial class SkillConditionEditor : UserControl, IObjectEditor
    {
        public SkillConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}