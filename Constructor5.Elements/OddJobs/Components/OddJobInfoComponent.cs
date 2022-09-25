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

        public Reference CustomerFilter { get; set; } = new Reference() { GameReference = 213139, GameReferenceLabel = "filter_Ages_YAE_OddJob_Customer" };

        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "OddJobInfo";

        public STBLString Description { get; set; } = new STBLString();

        public int DurationHours { get; set; } = 2;

        public bool HasTipIcon { get; set; } = false;
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
        public STBLString TipText { get; set; } = new STBLString() { CustomText = "0xA1A13D26 <<< None" };

        public void SaveUpgrade()
        {
            if (TipText.CustomText == "No Recommended Skill")
            {
                TipText.CustomText = "0xA1A13D26 <<< None";
            }
            else
            {
                HasTipIcon = true;
            }
        }

        protected internal override void OnExport(OddJobExportContext context)
        {
            var specialCasesComponent = context.Element.GetComponent<OddJobSpecialCasesComponent>();

            var assignmentsComponent = context.Element.GetComponent<OddJobAssignmentsComponent>();

            var bucket = !string.IsNullOrEmpty(specialCasesComponent.CustomBucket) ? specialCasesComponent.CustomBucket : $"OddJob_{Bucket}";

            if (!assignmentsComponent.IsAssignmentJob)
            {
                TuningActionInvoker.InvokeFromFile("Odd Job Rabbithole", new TuningActionContext
                {
                    DataContext = this,
                    Tuning = context.Tuning,
                    Variables =
                    {
                        { "Career", ElementTuning.GetSingleInstanceKey(specialCasesComponent.Career).ToString() },
                        { "Bucket", bucket }
                    }
                });
            }
            TuneDramaNode(context, bucket);

            if (ElementTuning.GetSingleInstanceKey(specialCasesComponent.Career) == 207004)
            {
                TuneCareerLevelModifiers(context);
            }
        }

        private void TuneCareerLevelModifiers(OddJobExportContext context)
        {
            var oddJobTuningTunable = context.Tuning.Get<TunableVariant>("odd_job_tuning").Get<TunableTuple>("enabled");

            var tunableList1 = oddJobTuningTunable.Get<TunableList>("result_based_gig_gratuity_multipliers");
            var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
            tunableTuple1.Set<TunableEnum>("key", "GREAT_SUCCESS");
            var tunableTuple2 = tunableTuple1.Get<TunableTuple>("value");
            tunableTuple2.Set<TunableBasic>("base_value", "0.1");
            var tunableList2 = tunableTuple2.Get<TunableList>("multipliers");
            var tunableTuple3 = tunableList2.Get<TunableTuple>(null);
            tunableTuple3.Set<TunableBasic>("multiplier", "2");
            var tunableList3 = tunableTuple3.Get<TunableList>("tests");
            var tunableList4 = tunableList3.Get<TunableList>(null);
            var tunableVariant1 = tunableList4.Set<TunableVariant>(null, "career_test");
            var tunableTuple4 = tunableVariant1.Get<TunableTuple>("career_test");
            var tunableVariant2 = tunableTuple4.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple5 = tunableVariant2.Get<TunableTuple>("career_level");
            tunableTuple5.Set<TunableBasic>("career_level", "209809");
            var tunableTuple6 = tunableList2.Get<TunableTuple>(null);
            tunableTuple6.Set<TunableBasic>("multiplier", "3");
            var tunableList5 = tunableTuple6.Get<TunableList>("tests");
            var tunableList6 = tunableList5.Get<TunableList>(null);
            var tunableVariant3 = tunableList6.Set<TunableVariant>(null, "career_test");
            var tunableTuple7 = tunableVariant3.Get<TunableTuple>("career_test");
            var tunableVariant4 = tunableTuple7.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple8 = tunableVariant4.Get<TunableTuple>("career_level");
            tunableTuple8.Set<TunableBasic>("career_level", "209810");
            var tunableTuple9 = tunableList2.Get<TunableTuple>(null);
            tunableTuple9.Set<TunableBasic>("multiplier", "4");
            var tunableList7 = tunableTuple9.Get<TunableList>("tests");
            var tunableList8 = tunableList7.Get<TunableList>(null);
            var tunableVariant5 = tunableList8.Set<TunableVariant>(null, "career_test");
            var tunableTuple10 = tunableVariant5.Get<TunableTuple>("career_test");
            var tunableVariant6 = tunableTuple10.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple11 = tunableVariant6.Get<TunableTuple>("career_level");
            tunableTuple11.Set<TunableBasic>("career_level", "209807");
            var tunableTuple12 = tunableList2.Get<TunableTuple>(null);
            tunableTuple12.Set<TunableBasic>("multiplier", "5");
            var tunableList9 = tunableTuple12.Get<TunableList>("tests");
            var tunableList10 = tunableList9.Get<TunableList>(null);
            var tunableVariant7 = tunableList10.Set<TunableVariant>(null, "career_test");
            var tunableTuple13 = tunableVariant7.Get<TunableTuple>("career_test");
            var tunableVariant8 = tunableTuple13.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple14 = tunableVariant8.Get<TunableTuple>("career_level");
            tunableTuple14.Set<TunableBasic>("career_level", "209808");
            var tunableTuple15 = tunableList1.Get<TunableTuple>(null);
            tunableTuple15.Set<TunableEnum>("key", "SUCCESS");
            var tunableTuple16 = tunableTuple15.Get<TunableTuple>("value");
            tunableTuple16.Set<TunableBasic>("base_value", "0.05");
            var tunableList11 = tunableTuple16.Get<TunableList>("multipliers");
            var tunableTuple17 = tunableList11.Get<TunableTuple>(null);
            tunableTuple17.Set<TunableBasic>("multiplier", "2");
            var tunableList12 = tunableTuple17.Get<TunableList>("tests");
            var tunableList13 = tunableList12.Get<TunableList>(null);
            var tunableVariant9 = tunableList13.Set<TunableVariant>(null, "career_test");
            var tunableTuple18 = tunableVariant9.Get<TunableTuple>("career_test");
            var tunableVariant10 = tunableTuple18.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple19 = tunableVariant10.Get<TunableTuple>("career_level");
            tunableTuple19.Set<TunableBasic>("career_level", "209809");
            var tunableTuple20 = tunableList11.Get<TunableTuple>(null);
            tunableTuple20.Set<TunableBasic>("multiplier", "3");
            var tunableList14 = tunableTuple20.Get<TunableList>("tests");
            var tunableList15 = tunableList14.Get<TunableList>(null);
            var tunableVariant11 = tunableList15.Set<TunableVariant>(null, "career_test");
            var tunableTuple21 = tunableVariant11.Get<TunableTuple>("career_test");
            var tunableVariant12 = tunableTuple21.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple22 = tunableVariant12.Get<TunableTuple>("career_level");
            tunableTuple22.Set<TunableBasic>("career_level", "209810");
            var tunableTuple23 = tunableList11.Get<TunableTuple>(null);
            tunableTuple23.Set<TunableBasic>("multiplier", "4");
            var tunableList16 = tunableTuple23.Get<TunableList>("tests");
            var tunableList17 = tunableList16.Get<TunableList>(null);
            var tunableVariant13 = tunableList17.Set<TunableVariant>(null, "career_test");
            var tunableTuple24 = tunableVariant13.Get<TunableTuple>("career_test");
            var tunableVariant14 = tunableTuple24.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple25 = tunableVariant14.Get<TunableTuple>("career_level");
            tunableTuple25.Set<TunableBasic>("career_level", "209807");
            var tunableTuple26 = tunableList11.Get<TunableTuple>(null);
            tunableTuple26.Set<TunableBasic>("multiplier", "5");
            var tunableList18 = tunableTuple26.Get<TunableList>("tests");
            var tunableList19 = tunableList18.Get<TunableList>(null);
            var tunableVariant15 = tunableList19.Set<TunableVariant>(null, "career_test");
            var tunableTuple27 = tunableVariant15.Get<TunableTuple>("career_test");
            var tunableVariant16 = tunableTuple27.Set<TunableVariant>("test_type", "career_level");
            var tunableTuple28 = tunableVariant16.Get<TunableTuple>("career_level");
            tunableTuple28.Set<TunableBasic>("career_level", "209808");
        }

        private void TuneDramaNode(OddJobExportContext context, string bucket)
        {
            var tuning = ElementTuning.Create(context.Element, "DramaNode");
            tuning.Class = "PickerDramaNode";
            tuning.InstanceType = "drama_node";
            tuning.Module = "drama_scheduler.picker_drama_node";

            var tunableVariant1 = tuning.Set<TunableVariant>("associated_sim_filter", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", CustomerFilter);
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
            tunableTuple4.Set<TunableEnum>("bucket", bucket);
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
                tunableVariant9.Set<TunableBasic>("specific_career", context.Element.GetComponent<OddJobSpecialCasesComponent>().Career);
                var tunableVariant10 = tunableTuple9.Set<TunableVariant>("user_level", "enabled");
                var tunableTuple10 = tunableVariant10.Get<TunableTuple>("enabled");
                tunableTuple10.Set<TunableBasic>("lower_bound", MinimumLevelRequired);
            }

            TuningExport.AddToQueue(tuning);
        }
    }
}