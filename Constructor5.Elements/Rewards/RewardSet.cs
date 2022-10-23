using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Rewards.RewardTypes;
using Constructor5.Elements.Traits.Components;
using System.Collections.ObjectModel;
using System.Linq;

namespace Constructor5.Elements.Rewards
{
    [ElementTypeData("RewardSet", true, PresetFolders = new[] { "Reward" })]
    public class RewardSet : Element, IExportableElement
    {
        public STBLString Description { get; set; } = new STBLString();
        public bool GenerateUIInfo { get; set; }
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public bool IsHouseholdReward { get; set; }
        public STBLString Name { get; set; } = new STBLString();
        public NotificationOrDialog Notification { get; set; } = new NotificationOrDialog();
        public ObservableCollection<RewardItem> Rewards { get; } = new ObservableCollection<RewardItem>();
        public bool ShowNotification { get; set; }

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

            var uiName = Name;
            var uiDescription = Description;
            var uiIcon = Icon;

            if (GenerateUIInfo)
            {
                var traitRewardItem = Rewards.FirstOrDefault(x=>x.Reward is TraitReward);
                if (traitRewardItem != null)
                {
                    var traitReward = (TraitReward)traitRewardItem.Reward;
                    if (traitReward.Trait.Element != null)
                    {
                        var infoComponent = ((Trait)traitReward.Trait.Element).GetTraitComponent<TraitInfoComponent>();
                        uiName = infoComponent.Name;
                        uiDescription = infoComponent.Description;
                        uiIcon = infoComponent.Icon;
                    }
                    else
                    {
                        Exporter.Current.AddError(this, $"{UserFacingId} is set to automatically generate the UI info from a custom trait reward, but the trait is not a custom trait from the mod.");
                        return;
                    }
                }
                else
                {
                    Exporter.Current.AddError(this, $"{UserFacingId} is set to automatically generate the UI info from a custom trait reward, but doesn't have one.");
                    return;
                }
            }

            tuning.Set<TunableBasic>("icon", uiIcon);
            tuning.Set<TunableBasic>("name", uiName);
            if (!string.IsNullOrEmpty(uiDescription.CustomText))
            {
                var tunableVariant1 = tuning.Set<TunableVariant>("reward_description", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", uiDescription);
            }

            tuning.SimDataHandler.WriteText(112, Exporter.Current.STBLBuilder.GetKey(uiName) ?? 0);
            tuning.SimDataHandler.WriteText(128, Exporter.Current.STBLBuilder.GetKey(uiDescription) ?? 0);
            tuning.SimDataHandler.WriteTGI(96, uiIcon.GetUncommentedText(), this);

            TuningExport.AddToQueue(tuning);
        }
    }
}