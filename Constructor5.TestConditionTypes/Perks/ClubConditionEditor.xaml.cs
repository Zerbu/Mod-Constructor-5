using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Perks
{
    [ObjectEditor(typeof(ClubCondition))]
    [ObjectEditor(typeof(ClubObjectiveCondition))]
    public partial class ClubConditionEditor : UserControl, IObjectEditor
    {
        public ClubConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}