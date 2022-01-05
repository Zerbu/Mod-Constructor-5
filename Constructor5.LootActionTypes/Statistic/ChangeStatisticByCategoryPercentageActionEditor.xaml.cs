using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Statistic
{
    [ObjectEditor(typeof(ChangeStatisticByCategoryPercentageAction))]
    public partial class ChangeStatisticByCategoryPercentageActionEditor : UserControl, IObjectEditor
    {
        public ChangeStatisticByCategoryPercentageActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}