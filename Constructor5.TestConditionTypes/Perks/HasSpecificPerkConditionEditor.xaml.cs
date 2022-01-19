using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Perks
{
    [ObjectEditor(typeof(HasSpecificPerkCondition))]
    public partial class HasSpecificPerkConditionEditor : UserControl, IObjectEditor
    {
        public HasSpecificPerkConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}