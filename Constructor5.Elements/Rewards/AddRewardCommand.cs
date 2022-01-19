using Constructor5.UI.Bases;
using System.Collections.Generic;

namespace Constructor5.Elements.Rewards
{
    public class AddRewardCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var list = (IList<RewardItem>)parameter;
            list.Add(new RewardItem { Reward = new EmptyReward() });
        }
    }
}
