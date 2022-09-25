using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Situations;

namespace Constructor5.SituationTemplates.CareerEventSituation
{
    //[SelectableObjectType("SituationTemplates", "CareerEventSituation")]
    [XmlSerializerExtraType]
    public class CareerEventSituationTemplate : SituationTemplate
    {
        public override string Label => "Career Event Situation";

        // todo: option to remove adult tag

        public Reference RoleState { get; set; } = new Reference();
        public Reference SituationJob { get; set; } = new Reference();

        protected override void OnExport(SituationExportContext context)
        {
            var header = (TuningHeader)context.Tuning;
            header.Class = "CareerEventSituation";
            header.Module = "careers.career_event_situation";

            /*var tunableVariant1 = context.Tuning.Set<TunableVariant>("build_buy_lock_reason", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", "0x2E9C7D1F");*/
            var tunableVariant2 = context.Tuning.Set<TunableVariant>("end_situation_dialog", "enabled");
            var tunableTuple1 = tunableVariant2.Get<TunableTuple>("enabled");
            var tunableList1 = tunableTuple1.Get<TunableList>("dialog_options");
            tunableList1.Set<TunableEnum>(null, "SMALL_TITLE");
            tunableTuple1.Set<TunableBasic>("is_special_dialog", "False");
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("text", "single");
            tunableVariant3.Set<TunableBasic>("single", "0xEE43B3C9");
            var tunableVariant4 = tunableTuple1.Set<TunableVariant>("text_alt_action", "enabled");
            var tunableTuple2 = tunableVariant4.Get<TunableTuple>("enabled");
            tunableTuple2.Set<TunableBasic>("disable", "True");
            tunableTuple2.Set<TunableBasic>("text_alt", "0xE162ABC2");
            tunableTuple1.Set<TunableBasic>("text_ok", "0x520A9B3F");
            var tunableVariant5 = tunableTuple1.Set<TunableVariant>("title", "enabled");
            tunableVariant5.Set<TunableBasic>("enabled", "0xBE9B7DC1");
            var tunableList2 = tunableTuple1.Get<TunableList>("ui_responses");
            var tunableVariant6 = context.Tuning.Set<TunableVariant>("situation_end_time_string", "show_end_time");
            tunableVariant6.Set<TunableBasic>("show_end_time", "0xA3E17143");
            var tunableList3 = context.Tuning.Get<TunableList>("tags");
            tunableList3.Set<TunableEnum>(null, "Situation_ActiveCareer");
            tunableList3.Set<TunableEnum>(null, "Situation_ActiveCareer_Adult");
            var tunableTuple3 = context.Tuning.Get<TunableTuple>("travel_request_behavior");
            var tunableVariant7 = tunableTuple3.Set<TunableVariant>("dialog", "enabled");
            var tunableTuple4 = tunableVariant7.Get<TunableTuple>("enabled");
            var tunableVariant8 = tunableTuple4.Set<TunableVariant>("icon", "enabled");
            var tunableVariant9 = tunableVariant8.Set<TunableVariant>("enabled", "participant");
            var tunableVariant10 = tunableTuple4.Set<TunableVariant>("text", "single");
            tunableVariant10.Set<TunableBasic>("single", "0xA19B9708");
            var tunableVariant11 = tunableTuple4.Set<TunableVariant>("title", "enabled");
            tunableVariant11.Set<TunableBasic>("enabled", "0x3EC9A8F6");
            var tunableTuple5 = context.Tuning.Get<TunableTuple>("user_job");
            tunableTuple5.Set<TunableBasic>("role_state", RoleState);
            tunableTuple5.Set<TunableBasic>("situation_job", SituationJob);

        }
    }
}