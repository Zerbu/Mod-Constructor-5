using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.TestConditionTypes.Money
{
    [ObjectEditor(typeof(SimoleonValueCondition))]
    public partial class SimoleonValueConditionEditor : UserControl, IObjectEditor
    {
        public SimoleonValueConditionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}