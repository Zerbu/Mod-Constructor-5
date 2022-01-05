using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Statistic
{
    [ObjectEditor(typeof(SetStatisticToRandomValueInRangeAction))]
    public partial class SetStatisticToRandomValueInRangeActionEditor : UserControl, IObjectEditor
    {
        public SetStatisticToRandomValueInRangeActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}