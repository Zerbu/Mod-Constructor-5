using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Rewards
{
    [ElementTypeData("Reward Set", false, PresetFolders = new[] { "Reward" })]
    public class RewardSet : Element, IExportableElement
    {
        public bool ShowNotification { get; set; }
        public STBLString Description { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public bool IsHouseholdReward { get; set; }
        public STBLString Name { get; set; } = new STBLString();
        public NotificationOrDialog Notification { get; set; } = new NotificationOrDialog();
        public ObservableCollection<RewardItem> Rewards { get; } = new ObservableCollection<RewardItem>();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = IsHouseholdReward ? "HouseholdReward" : "SimReward";
            tuning.InstanceType = "reward";
            tuning.Module = "rewards.reward";

            tuning.SimDataHandler = new SimDataHandler($"SimData/Reward.data");

            var listTunable = tuning.Get<TunableList>("rewards");
            foreach (var rewardItem in Rewards)
            {
                if (rewardItem.Reward is EmptyReward)
                {
                    continue;
                }

                var variantName = rewardItem.Reward.GetVariantName();
                var variantTunable = variantName != null ?
                    listTunable.Set<TunableVariant>(null, "specific_reward").Set<TunableVariant>("specific_reward", rewardItem.Reward.GetVariantName())
                    : listTunable;
                rewardItem.Reward.OnExport(new RewardExportContext
                {
                    Tunable = variantTunable,
                    Element = this
                });
            }

            if (ShowNotification)
            {
                TuningActionInvoker.InvokeFromFile("Notification Loot",
                    new TuningActionContext
                    {
                        Tuning = tuning.Set<TunableVariant>("notification", "enabled").Set<TunableVariant>("enabled", "literal").Get<TunableTuple>("literal"),
                        DataContext = Notification
                    });
            }

            tuning.Set<TunableBasic>("name", Name);
            if (!string.IsNullOrEmpty(Description.CustomText))
            {
                var tunableVariant1 = tuning.Set<TunableVariant>("reward_description", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", Description);
            }

            tuning.SimDataHandler.WriteText(112, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            tuning.SimDataHandler.WriteText(128, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
            tuning.SimDataHandler.WriteTGI(96, Icon.GetUncommentedText());

            TuningExport.AddToQueue(tuning);
        }
    }
}