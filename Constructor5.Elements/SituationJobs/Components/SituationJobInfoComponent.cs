using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.SituationJobs.Components
{
    [XmlSerializerExtraType]
    public class SituationJobInfoComponent : SituationJobComponent
    {
        [AutoTuneTupleRange("auto_invite")]
        public IntBounds AutoInviteSimCount { get; set; } = new IntBounds();

        [AutoTuneIfFalse("can_be_hired")]
        public bool CanBeHired { get; set; }

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Situation Job Info";

        [AutoTuneIfTrue("confirm_leave_situation_for_work")]
        public bool ConfirmLeaveForWork { get; set; } = true;

        [AutoTuneBasic("job_description")]
        public STBLString Description { get; set; } = new STBLString();

        [AutoTuneIfTrue("elevated_importance")]
        public bool ElevatedImportance { get; set; }

        [AutoTuneBasic("hire_cost", IgnoreIf = 0)]
        public int HireCost { get; set; }

        [AutoTuneBasic("display_name")]
        public STBLString Name { get; set; } = new STBLString();

        [AutoTuneIfTrue("participating_npcs_should_ignore_work")]
        public bool NPCsShouldIgnoreWork { get; set; } = true;

        [AutoTuneTupleRange("sim_count")]
        public IntBounds PlayerInviteSimCount { get; set; } = new IntBounds();

        public bool ReplaceOnLeave { get; set; }
        public bool ReplaceOnNoShow { get; set; }
        public bool RestrictTooltip { get; set; }

        protected internal override void OnExport(SituationJobExportContext context)
        {
            if (ReplaceOnLeave)
            {
                context.Tuning.Set<TunableBasic>("died_or_left_action", "REPLACE_THEM");
            }

            if (ReplaceOnNoShow)
            {
                context.Tuning.Set<TunableBasic>("no_show_action", "REPLACE_THEM");
            }

            if (!RestrictTooltip)
            {
                context.Tuning.Set<TunableBasic>("user_facing_sim_headline_display_override", "True");
            }

            context.Tuning.Set<TunableBasic>("tooltip_name", Name);
            var tunableTuple1 = context.Tuning.Get<TunableTuple>("tooltip_name_text_tokens");
            var tunableList1 = tunableTuple1.Get<TunableList>("tokens");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "participant_type");

            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}