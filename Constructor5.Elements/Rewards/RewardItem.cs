using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.ComponentModel;

namespace Constructor5.Elements.Rewards
{
    public class RewardItem : INotifyPropertyChanged
    {
        public Reward Reward { get; set; } = new EmptyReward();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
