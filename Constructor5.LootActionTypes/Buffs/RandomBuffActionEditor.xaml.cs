using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.LootActionTypes.Buffs
{
    [ObjectEditor(typeof(RandomBuffAction))]
    public partial class RandomBuffActionEditor : UserControl, IObjectEditor
    {
        public RandomBuffActionEditor() => InitializeComponent();

        public void SetObject(object obj, string tag) => DataContext = obj;
    }
}