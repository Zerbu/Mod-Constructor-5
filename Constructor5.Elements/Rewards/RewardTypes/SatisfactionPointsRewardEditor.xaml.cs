using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(SatisfactionPointsReward))]
    public partial class SatisfactionPointsRewardEditor : UserControl, IObjectEditor
    {
        public SatisfactionPointsRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}