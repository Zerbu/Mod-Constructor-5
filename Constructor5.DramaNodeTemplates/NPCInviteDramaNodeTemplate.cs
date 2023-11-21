using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.DramaNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.DramaNodeTemplates
{
    [SelectableObjectType("DramaNodeTemplates", "NPCInviteDramaNodeTemplate")]
    [XmlSerializerExtraType]
    public class NPCInviteDramaNodeTemplate : DramaNodeTemplate
    {
        public override string Label => "NPC Invite Drama Node";

        public Reference InviterSimFilter { get; set; } = new Reference();

        public Reference SituationToRun { get; set; } = new Reference();

        public Reference PlayerJob { get; set; } = new Reference();
        public Reference InviterJob { get; set; } = new Reference();


        public Reference OtherSimsJob { get; set; } = new Reference();
        public Reference OtherSimsFilter { get; set; } = new Reference();

        public STBLString MessageText { get; set; } = new STBLString();

        public bool AllowDuringWorkHours { get; set; }

        public bool UninstancedSimsOnly { get; set; }

        public bool IsGoaled { get; set; }

        protected override void OnExport(DramaNodeExportContext context)
        {
            var tuningHeader = (TuningHeader)context.Tuning;
            tuningHeader.Class = "NPCInviteSituationDramaNode";
            tuningHeader.Module = "drama_scheduler.npc_invite_situation_drama_node";

            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("_NPC_host_job", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", InviterJob);
                var tunableVariant2 = context.Tuning.Set<TunableVariant>("_NPC_hosted_situation_player_job", "enabled");
                tunableVariant2.Set<TunableBasic>("enabled", PlayerJob);
                var tunableList1 = context.Tuning.Get<TunableList>("_NPC_hosted_situation_start_messages");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("dialog");
                var tunableVariant3 = tunableTuple2.Set<TunableVariant>("bring_other_sims", "enabled");
                var tunableTuple3 = tunableVariant3.Get<TunableTuple>("enabled");
                var tunableTuple4 = tunableTuple3.Get<TunableTuple>("picker_dialog");
                var tunableVariant4 = tunableTuple4.Set<TunableVariant>("max_selectable", "static_count");
                var tunableTuple5 = tunableVariant4.Get<TunableTuple>("static_count");
                tunableTuple5.Set<TunableBasic>("number_selectable", "7");
                tunableTuple4.Set<TunableBasic>("min_selectable", "0");
                var tunableVariant5 = tunableTuple4.Set<TunableVariant>("text", "enabled");
                var tunableVariant6 = tunableVariant5.Set<TunableVariant>("enabled", "single");
                tunableVariant6.Set<TunableBasic>("single", "0x99DAAC93");
                var tunableVariant7 = tunableTuple4.Set<TunableVariant>("title", "enabled");
                tunableVariant7.Set<TunableBasic>("enabled", "0x2D6EE79D");
                tunableTuple3.Set<TunableBasic>("situation_job", OtherSimsJob);
                tunableTuple3.Set<TunableBasic>("text", "0x976CE076");
                tunableTuple3.Set<TunableBasic>("travel_with_filter", OtherSimsFilter);
                tunableTuple2.Set<TunableEnum>("phone_ring_type", "BUZZ");
                var tunableVariant8 = tunableTuple2.Set<TunableVariant>("text", "single");
                tunableVariant8.Set<TunableBasic>("single", MessageText);
                var tunableVariant9 = tunableTuple2.Set<TunableVariant>("text_tokens", "enabled");
                var tunableTuple6 = tunableVariant9.Get<TunableTuple>("enabled");
                var tunableList2 = tunableTuple6.Get<TunableList>("tokens");
                var tunableVariant10 = tunableList2.Set<TunableVariant>(null, "participant_type");
                tunableTuple2.Set<TunableBasic>("zone_title", "0xC79595F2");

                context.Tuning.Set<TunableBasic>("_situation_to_run", SituationToRun);

                if (!AllowDuringWorkHours)
                {
                    context.Tuning.Set<TunableBasic>("allow_during_work_hours", "False");
                }

                if (!UninstancedSimsOnly)
                {
                    context.Tuning.Set<TunableEnum>("sender_sim_info_type", "INSTANCED_ALLOWED");
                }
            }

            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("cooldown_data", "group_cooldown");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("group_cooldown");
                tunableTuple1.Set<TunableEnum>("group", "InviteCooldown");
                var tunableVariant2 = context.Tuning.Set<TunableVariant>("sender_sim_info", "sim_filter");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("sim_filter");
                var tunableList1 = tunableTuple2.Get<TunableList>("blacklist_participants");
                tunableList1.Set<TunableEnum>(null, "");
                tunableTuple2.Set<TunableBasic>("sim_filter", InviterSimFilter);
            }

            if (IsGoaled)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("scoring", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                tunableTuple1.Set<TunableBasic>("base_score", "10");
            }
        }
    }
}
