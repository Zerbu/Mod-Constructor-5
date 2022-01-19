using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Statistic
{
    [ObjectEditor(typeof(SetStatisticToExactValueAction))]
    public partial class SetStatisticToExactValueActionEditor : UserControl, IObjectEditor
    {
        public SetStatisticToExactValueActionEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}