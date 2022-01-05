using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Statistic
{
    [ObjectEditor(typeof(ChangeStatisticByRelativeValueAction))]
    public partial class ChangeStatisticByRelativeValueActionEditor : UserControl, IObjectEditor
    {
        public ChangeStatisticByRelativeValueActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}