using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(PerkPointsReward))]
    public partial class PerkPointsRewardEditor : UserControl, IObjectEditor
    {
        public PerkPointsRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}