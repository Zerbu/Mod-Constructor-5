using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Perks
{
    [ObjectEditor(typeof(ClubPointsEarnedCondition))]
    public partial class ClubPointsEarnedConditionEditor : UserControl, IObjectEditor
    {
        public ClubPointsEarnedConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}