using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.Situations.Components
{
    [XmlSerializerExtraType]
    public class SituationInfoComponent : SituationComponent
    {
        [AutoTuneBasic("calendar_icon")]
        public ElementIcon CalendarIcon { get; set; } = new ElementIcon();

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Situation Info";

        [AutoTuneBasic("_cost")]
        public int Cost { get; set; } = 0;

        [AutoTuneBasic("situation_description")]
        public STBLString Description { get; set; } = new STBLString();

        [AutoTuneBasic("duration")]
        public int Duration { get; set; } = 360;

        [AutoTuneBasic("_icon")]
        public ElementIcon Icon { get; set; } = new ElementIcon();

        public bool IsSocialEvent { get; set; }

        [AutoTuneBasic("max_participants")]
        public int MaxParticipants { get; set; } = 20;

        [AutoTuneBasic("_display_name")]
        public STBLString Name { get; set; } = new STBLString();

        protected internal override void OnExport(SituationExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            if (IsSocialEvent)
            {
                context.Tuning.Set<TunableBasic>("_implies_greeted_status", "True");
                context.Tuning.Set<TunableBasic>("blocks_super_speed_three", "True");
                context.Tuning.Set<TunableEnum>("category", "Social Events");
                context.Tuning.Set<TunableBasic>("force_invite_only", "True");
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("recommended_job_object_notification");
                tunableTuple1.Set<TunableEnum>("information_level", "SIM");
                context.Tuning.Set<TunableBasic>("recommended_job_object_text", "0x7E73F37A");

                var tunableList1 = context.Tuning.Get<TunableList>("tags");
                tunableList1.Set<TunableEnum>(null, "Situation_PlayerFacing_CanHost");
                var tunableVariant9 = context.Tuning.Set<TunableVariant>("travel_request_behavior", "allow");
                var tunableTuple2 = tunableVariant9.Get<TunableTuple>("allow");
                var tunableVariant10 = tunableTuple2.Set<TunableVariant>("dialog", "enabled");
                var tunableTuple3 = tunableVariant10.Get<TunableTuple>("enabled");
                var tunableVariant11 = tunableTuple3.Set<TunableVariant>("icon", "enabled");
                var tunableVariant12 = tunableVariant11.Set<TunableVariant>("enabled", "resource_key");
                var tunableTuple4 = tunableVariant12.Get<TunableTuple>("resource_key");
                tunableTuple4.Set<TunableBasic>("key", "2f7d0004:00000000:4f27caa127291bd5");
                var tunableVariant13 = tunableTuple3.Set<TunableVariant>("text", "single");
                tunableVariant13.Set<TunableBasic>("single", "0xE8A540E3");
                var tunableVariant14 = tunableTuple3.Set<TunableVariant>("title", "enabled");
                tunableVariant14.Set<TunableBasic>("enabled", "0xFECDCF71");

            }
        }
    }
}