using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Statistic
{
    [ObjectEditor(typeof(ChangeStatisticByCategoryFixedAction))]
    public partial class ChangeStatisticByCategoryFixedActionEditor : UserControl, IObjectEditor
    {
        public ChangeStatisticByCategoryFixedActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}
