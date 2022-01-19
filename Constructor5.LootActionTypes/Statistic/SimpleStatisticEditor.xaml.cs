using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Statistic
{
    [ObjectEditor(typeof(AddStatisticAction))]
    [ObjectEditor(typeof(RemoveStatisticAction))]
    [ObjectEditor(typeof(SetStatisticToMaxAction))]
    [ObjectEditor(typeof(SetStatisticToMinAction))]
    public partial class SimpleStatisticEditor : UserControl, IObjectEditor
    {
        public SimpleStatisticEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;
    }
}
