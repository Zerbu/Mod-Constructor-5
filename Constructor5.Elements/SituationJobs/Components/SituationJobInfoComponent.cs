using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.SituationJobs.Components
{
    [XmlSerializerExtraType]
    public class SituationJobInfoComponent : SituationJobComponent
    {
        [AutoTuneTupleRange("sim_auto_invite")]
        public IntBounds AutoInviteSimCount { get; set; } = new IntBounds();

        [AutoTuneIfFalse("can_be_hired")]
        public bool CanBeHired { get; set; }

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "SituationJobInfo";

        [AutoTuneIfTrue("confirm_leave_situation_for_work")]
        public bool ConfirmLeaveForWork { get; set; } = true;

        [AutoTuneBasic("job_description")]
        public STBLString Description { get; set; } = new STBLString();

        [AutoTuneIfTrue("elevated_importance")]
        public bool ElevatedImportance { get; set; }

        [AutoTuneBasic("hire_cost", IgnoreIf = 0)]
        public int HireCost { get; set; }

        public bool IsCareerEventPlayerSituation { get; set; }

        [AutoTuneBasic("display_name")]
        public STBLString Name { get; set; } = new STBLString();

        [AutoTuneIfTrue("participating_npcs_should_ignore_work")]
        public bool NPCsShouldIgnoreWork { get; set; } = true;

        [AutoTuneTupleRange("sim_count", LowerDefaultOverride = 0)]
        public IntBounds PlayerInviteSimCount { get; set; } = new IntBounds();

        public bool ReplaceOnLeave { get; set; }
        public bool ReplaceOnNoShow { get; set; }
        public bool RestrictTooltip { get; set; } = true;

        public ObservableCollection<string> RoleTags { get; } = new ObservableCollection<string>();

        protected internal override void OnExport(SituationJobExportContext context)
        {
            if (ReplaceOnLeave)
            {
                context.Tuning.Set<TunableBasic>("died_or_left_action", "REPLACE_THEM");
            }
            else if (IsCareerEventPlayerSituation)
            {
                context.Tuning.Set<TunableEnum>("died_or_left_action", "END_SITUATION");
            }

            if (ReplaceOnNoShow)
            {
                context.Tuning.Set<TunableBasic>("no_show_action", "REPLACE_THEM");
            }

            if (!RestrictTooltip)
            {
                context.Tuning.Set<TunableBasic>("user_facing_sim_headline_display_override", "True");
            }

            //if (!IsCareerEventSituation)
            //{
            context.Tuning.Set<TunableBasic>("tooltip_name", Name);
            var tunableTuple1 = context.Tuning.Get<TunableTuple>("tooltip_name_text_tokens");
            var tunableList1 = tunableTuple1.Get<TunableList>("tokens");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "participant_type");
            //}
            if (IsCareerEventPlayerSituation)
            {
                var list = context.Tuning.Get<TunableList>("tags");
                list.Set<TunableEnum>(null, "Role_Career");

                /*context.Tuning.Set<TunableBasic>("tooltip_name", "0xA5A034C1");
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("tooltip_name_text_tokens");
                var tunableList1 = tunableTuple1.Get<TunableList>("tokens");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "participant_type");
                var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "career_data");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("career_data");
                var tunableVariant3 = tunableTuple2.Set<TunableVariant>("career_data", "current_level_name");
                tunableTuple2.Set<TunableBasic>("career_type", "107230");*/
            }

            if (RoleTags.Count > 0)
            {
                var tunableList2 = context.Tuning.Get<TunableList>("tags");
                foreach (var tag in RoleTags)
                {
                    tunableList2.Set<TunableEnum>(null, tag);
                }
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}