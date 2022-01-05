using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.CompoundConditionElements
{
    [ObjectEditor(typeof(CompoundConditionElement))]
    public partial class CompoundConditionElementEditor : UserControl, IObjectEditor
    {
        public CompoundConditionElementEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}