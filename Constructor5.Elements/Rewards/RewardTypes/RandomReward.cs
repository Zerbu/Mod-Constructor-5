using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Rewards.RewardTypes
{
    [SelectableObjectType("RewardTypes", "RandomReward")]
    [XmlSerializerExtraType]
    public class RandomReward : Reward
    {
        public RandomReward() => GeneratedLabel = "Random Reward";

        public ObservableCollection<RewardItem> PossibleRewards { get; } = new ObservableCollection<RewardItem>();

        protected internal override string GetVariantName() => null;

        protected internal override void OnExport(RewardExportContext context)
        {
            var randomList = context.Tunable.GetVariant<TunableList>(null, "random_reward");

            foreach (var rewardItem in PossibleRewards)
            {
                if (rewardItem.Reward is EmptyReward)
                {
                    continue;
                }

                var tuple = randomList.Get<TunableTuple>(null);
                var variant = tuple.Set<TunableVariant>("reward", rewardItem.Reward.GetVariantName());
                
                rewardItem.Reward.OnExport(new RewardExportContext
                {
                    Tunable = variant,
                    Element = context.Element
                });
            }
        }
    }
}