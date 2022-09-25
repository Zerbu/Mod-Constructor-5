using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Relationships
{
    [ObjectEditor(typeof(GenderPreferenceCondition))]
    public partial class GenderPreferenceConditionEditor : UserControl, IObjectEditor
    {
        public GenderPreferenceConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}