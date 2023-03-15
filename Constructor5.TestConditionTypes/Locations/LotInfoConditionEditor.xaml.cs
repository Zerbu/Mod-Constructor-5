using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Locations
{
    [ObjectEditor(typeof(LotInfoCondition))]
    public partial class LotInfoConditionEditor : UserControl, IObjectEditor
    {
        public LotInfoConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }
    }
}