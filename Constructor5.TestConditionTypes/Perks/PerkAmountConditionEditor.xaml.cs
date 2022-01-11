using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Perks
{
    [ObjectEditor(typeof(PerkAmountCondition))]
    public partial class PerkAmountConditionEditor : UserControl, IObjectEditor
    {
        public PerkAmountConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}