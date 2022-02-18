using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.ComponentModel;

namespace Constructor5.Elements.Rewards
{
    public class RewardItem : INotifyPropertyChanged
    {
        public Reward Reward { get; set; } = new EmptyReward();

#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067
    }
}
