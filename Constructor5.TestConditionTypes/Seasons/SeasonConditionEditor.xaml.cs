using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Seasons
{
    [ObjectEditor(typeof(SeasonCondition))]
    public partial class SeasonConditionEditor : UserControl, IObjectEditor
    {
        public SeasonConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}