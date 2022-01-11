using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.Buffs.References;

namespace Constructor5.Elements.HolidayTraditions.Components
{
    [XmlSerializerExtraType]
    public class HolidayTraditionBuffsComponent : HolidayTraditionComponent
    {
        [AutoTuneReferenceList("holiday_buffs")]
        public ReferenceList Buffs { get; set; } = new ReferenceList();

        public override string ComponentLabel => "Holiday Buffs";

        public BuffWithReason LovesRewardBuff { get; set; } = new BuffWithReason();

        [AutoTuneReferenceList("pre_holiday_buffs")]
        public ReferenceList PreBuffs { get; set; } = new ReferenceList();
        public STBLString PreReason { get; set; } = new STBLString();
        public STBLString Reason { get; set; } = new STBLString();

        protected internal override void OnExport(HolidayTraditionExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            if (!string.IsNullOrEmpty(Reason.CustomText))
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("holiday_buff_reason", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", Reason);
            }

            if (!string.IsNullOrEmpty(PreReason.CustomText))
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("pre_holiday_buff_reason", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", PreReason);
            }

            var rewardBuffKey = ElementTuning.GetSingleInstanceKey(LovesRewardBuff.Buff);
            if (rewardBuffKey != null)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("preference_reward_buff", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                if (!string.IsNullOrEmpty(LovesRewardBuff.Reason.CustomText))
                {
                    var tunableVariant2 = tunableTuple1.Set<TunableVariant>("buff_reason", "enabled");
                    tunableVariant2.Set<TunableBasic>("enabled", LovesRewardBuff.Reason);
                }
                tunableTuple1.Set<TunableBasic>("buff_type", LovesRewardBuff.Buff);
            }
        }
    }
}