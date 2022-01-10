using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(MoneyRandomAmount))]
    public partial class MoneyRandomAmountEditor : UserControl, IObjectEditor
    {
        public MoneyRandomAmountEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}