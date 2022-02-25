using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.OddJobs.Components
{
    [XmlSerializerExtraType]
    public class OddJobInfoComponent : OddJobComponent
    {
        public OddJobBuckets Bucket { get; set; } = OddJobBuckets.Low;

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "OddJobInfo";

        public STBLString Description { get; set; } = new STBLString();

        public int DurationHours { get; set; } = 2;

        public ElementIcon Icon { get; set; } = new ElementIcon();

        public int MinimumLevelRequired { get; set; } = 1;

        public STBLString Name { get; set; } = new STBLString();

        public STBLString NotificationFailure { get; set; } = new STBLString() { CustomText = @"{0.SimFirstName} did a terrible job.

<b>Outcome:</b>
{7.String}" };

        public STBLString NotificationFailureCritical { get; set; } = new STBLString() { CustomText = @"{0.SimFirstName} did a poor job.

<b>Outcome:</b>
{7.String}" };

        public STBLString NotificationSuccess { get; set; } = new STBLString() { CustomText = @"{0.SimFirstName} did a good job.

<b>Outcome:</b>
{7.String}" };

        public STBLString NotificationSuccessGreat { get; set; } = new STBLString() { CustomText = @"{0.SimFirstName} did a great job.

<b>Outcome:</b>
{7.String}" };

        public int PayAmount { get; set; }

        public Reference RecommendedSkill { get; set; } = new Reference();
        public int RecommendedSkillLevel { get; set; } = 1;
        public int RecommendedSkillLevelTolerance { get; set; } = 2;

        public ElementIcon TipIcon { get; set; } = new ElementIcon();
        public STBLString TipText { get; set; } = new STBLString() { CustomText = "No Recommended Skill" };

        protected internal override void OnExport(OddJobExportContext context)
        {
            var assignmentsComponent = context.Element.GetComponent<OddJobAssignmentsComponent>();

            if (!assignmentsComponent.IsAssignmentJob)
            {
                TuningActionInvoker.InvokeFromFile("Odd Job Rabbithole", new TuningActionContext
                {
                    DataContext = this,
                    Tuning = context.Tuning
                });
            }
            TuneDramaNode(context);
        }

        private void TuneDramaNode(OddJobExportContext context)
        {
            var tuning = ElementTuning.Create(context.Element, "DramaNode");
            tuning.Class = "PickerDramaNode";
            tuning.InstanceType = "drama_node";
            tuning.Module = "drama_scheduler.picker_drama_node";

            var tunableVariant1 = tuning.Set<TunableVariant>("associated_sim_filter", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", "213139");
            var tunableVariant2 = tuning.Set<TunableVariant>("behavior", "schedule_career_gig");
            var tunableTuple1 = tunableVariant2.Get<TunableTuple>("schedule_career_gig");
            tunableTuple1.Set<TunableBasic>("allow_add_career", "True");
            tunableTuple1.Set<TunableBasic>("career_gig", ElementTuning.GetSingleInstanceKey(context.Element));
            var tunableVariant3 = tuning.Set<TunableVariant>("cooldown_data", "node_cooldown");
            var tunableTuple2 = tunableVariant3.Get<TunableTuple>("node_cooldown");
            tunableTuple2.Set<TunableEnum>("cooldown_option", "ON_SCHEDULE");
            var tunableVariant4 = tunableTuple2.Set<TunableVariant>("duration", "duration");
            tunableVariant4.Set<TunableBasic>("duration", "25");
            var tunableTuple3 = tuning.Get<TunableTuple>("min_and_max_times");
            tunableTuple3.Set<TunableBasic>("lower_bound", "24");
            tunableTuple3.Set<TunableBasic>("upper_bound", "48");
            tuning.Set<TunableEnum>("on_pick_behavior", "DISABLE_FOR_ALL_SIMS");
            var tunableVariant5 = tuning.Set<TunableVariant>("scoring", "enabled");
            var tunableTuple4 = tunableVariant5.Get<TunableTuple>("enabled");
            tunableTuple4.Set<TunableEnum>("bucket", $"OddJob_{Bucket}");
            var tunableVariant6 = tuning.Set<TunableVariant>("time_option", "schedule");
            var tunableTuple5 = tunableVariant6.Get<TunableTuple>("schedule");
            var tunableList1 = tunableTuple5.Get<TunableList>("valid_times");
            var tunableTuple6 = tunableList1.Get<TunableTuple>(null);
            var tunableTuple7 = tunableTuple6.Get<TunableTuple>("days_available");
            tunableTuple7.Set<TunableBasic>("0 SUNDAY", "True");
            tunableTuple7.Set<TunableBasic>("1 MONDAY", "True");
            tunableTuple7.Set<TunableBasic>("2 TUESDAY", "True");
            tunableTuple7.Set<TunableBasic>("3 WEDNESDAY", "True");
            tunableTuple7.Set<TunableBasic>("4 THURSDAY", "True");
            tunableTuple7.Set<TunableBasic>("5 FRIDAY", "True");
            tunableTuple7.Set<TunableBasic>("6 SATURDAY", "True");
            tunableTuple6.Set<TunableBasic>("duration", "8");

            if (MinimumLevelRequired > 1)
            {
                var tunableList2 = tuning.Get<TunableList>("visibility_tests");
                var tunableList3 = tunableList2.Get<TunableList>(null);
                var tunableVariant7 = tunableList3.Set<TunableVariant>(null, "career_test");
                var tunableTuple8 = tunableVariant7.Get<TunableTuple>("career_test");
                var tunableVariant8 = tunableTuple8.Set<TunableVariant>("test_type", "career_reference");
                var tunableTuple9 = tunableVariant8.Get<TunableTuple>("career_reference");
                tunableTuple9.Set<TunableBasic>("allow_invisible_careers", "True");
                var tunableVariant9 = tunableTuple9.Set<TunableVariant>("career", "specific_career");
                tunableVariant9.Set<TunableBasic>("specific_career", "207004");
                var tunableVariant10 = tunableTuple9.Set<TunableVariant>("user_level", "enabled");
                var tunableTuple10 = tunableVariant10.Get<TunableTuple>("enabled");
                tunableTuple10.Set<TunableBasic>("lower_bound", MinimumLevelRequired);
            }

            TuningExport.AddToQueue(tuning);
        }
    }
}