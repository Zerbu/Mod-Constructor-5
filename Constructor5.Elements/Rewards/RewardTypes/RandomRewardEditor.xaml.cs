using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [ObjectEditor(typeof(RandomReward))]
    public partial class RandomRewardEditor : UserControl, IObjectEditor
    {
        public RandomRewardEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag) => DataContext = obj;
    }
}