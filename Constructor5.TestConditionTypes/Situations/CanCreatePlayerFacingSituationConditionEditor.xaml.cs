using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Situations
{
    [ObjectEditor(typeof(CanCreatePlayerFacingSituationCondition))]
    public partial class CanCreatePlayerFacingSituationConditionEditor : UserControl, IObjectEditor
    {
        public CanCreatePlayerFacingSituationConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}