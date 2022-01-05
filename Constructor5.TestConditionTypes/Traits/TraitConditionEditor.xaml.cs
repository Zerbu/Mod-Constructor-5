using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Traits
{
    [ObjectEditor(typeof(TraitCondition))]
    public partial class TraitConditionEditor : UserControl, IObjectEditor
    {
        public TraitConditionEditor()
        {
            InitializeComponent();
        }

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
