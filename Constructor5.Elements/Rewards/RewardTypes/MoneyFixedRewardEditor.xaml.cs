using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(MoneyFixedReward))]
    public partial class MoneyFixedRewardEditor : UserControl, IObjectEditor
    {
        public MoneyFixedRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}