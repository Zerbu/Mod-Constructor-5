using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.Python;
using Constructor5.Core;

namespace Constructor5.Elements.Situations.Components
{
    [XmlSerializerExtraType]
    public class SituationGoaledEventComponent : SituationComponent
    {
        public ReferenceList ActivitiesOptional { get; set; } = new ReferenceList();
        public ReferenceList ActivitiesRequired { get; set; } = new ReferenceList();

        public ElementIcon BronzeIcon { get; set; } = new ElementIcon();
        public Reference BronzeReward { get; set; } = new Reference();

        public override string ComponentLabel => "GoaledEvent";

        public bool DisguiseAsNonGoaledEvent { get; set; }

        public STBLString ForcedGoaledEventToolTip { get; set; } = new STBLString() { CustomText = "This is a forced goaled event." };

        [AutoTuneReferenceList("minor_goal_chains")]
        public ReferenceList GoalSets { get; set; } = new ReferenceList();

        public ElementIcon GoldIcon { get; set; } = new ElementIcon();
        public Reference GoldReward { get; set; } = new Reference();
        public bool IsForcedGoaledEvent { get; set; }
        public bool IsGoaledEvent { get; set; }
        public bool IsHidden { get; set; }

        [AutoTuneBasic("main_goal")]
        public Reference MainGoal { get; set; } = new Reference();

        public bool OverrideIcons { get; set; }
        public int ScoreToReachBronze { get; set; } = 100;
        public int ScoreToReachGold { get; set; } = 30;
        public int ScoreToReachSilver { get; set; } = 30;
        public ElementIcon SilverIcon { get; set; } = new ElementIcon();
        public Reference SilverReward { get; set; } = new Reference();

        public bool ShowScreenSlamEffects { get; set; } = true;

        public bool SuppressAutomaticBronzeTraits { get; set; }

        protected internal override void OnExport(SituationExportContext context)
        {
            if (!IsGoaledEvent)
            {
                return;
            }

            if (ShowScreenSlamEffects)
            {
                TuneScreenSlam(context);
            }

            var tunableTuple1 = context.Tuning.Get<TunableTuple>("_level_data");
            var tunableTuple2 = tunableTuple1.Get<TunableTuple>("bronze");
            if (!IsHidden && OverrideIcons)
            {
                tunableTuple2.Set<TunableBasic>("icon", BronzeIcon);
            }
            tunableTuple2.Set<TunableBasic>("level_description", "0x9224E9B0");
            tunableTuple2.Set<TunableBasic>("reward", BronzeReward);
            if (ScoreToReachBronze != 30)
            {
                tunableTuple2.Set<TunableBasic>("score_delta", ScoreToReachBronze);
            }

            var tunableTuple3 = tunableTuple1.Get<TunableTuple>("gold");
            if (!IsHidden && OverrideIcons)
            {
                tunableTuple3.Set<TunableBasic>("icon", GoldIcon);
            }
            tunableTuple3.Set<TunableBasic>("level_description", "0x82AD9EEA");
            tunableTuple3.Set<TunableBasic>("reward", GoldReward);
            if (ScoreToReachGold != 30)
            {
                tunableTuple3.Set<TunableBasic>("score_delta", ScoreToReachGold);
            }

            var tunableTuple4 = tunableTuple1.Get<TunableTuple>("silver");
            if (!IsHidden && OverrideIcons)
            {
                tunableTuple4.Set<TunableBasic>("icon", SilverIcon);
            }
            tunableTuple4.Set<TunableBasic>("level_description", "0x20CAEAD3");
            tunableTuple4.Set<TunableBasic>("reward", SilverReward);
            if (ScoreToReachGold != 30)
            {
                tunableTuple4.Set<TunableBasic>("score_delta", ScoreToReachSilver);
            }

            if (IsHidden)
            {
                context.Tuning.Set<TunableBasic>("_hidden_scoring_override", "True");
            }
            else if (IsForcedGoaledEvent)
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("scoring_lock_reason", "enabled");
                tunableVariant1.Set<TunableBasic>("enabled", ForcedGoaledEventToolTip);
            }

            if (ActivitiesOptional.HasItems() || ActivitiesRequired.HasItems())
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("goal_tracker_type", "simple_situation_goal_tracker");
                tunableVariant1.Get<TunableTuple>("simple_situation_goal_tracker");
                var tunableVariant2 = context.Tuning.Set<TunableVariant>("situation_display_type_override", "enabled");
                tunableVariant2.Set<TunableEnum>("enabled", "ACTIVITY");

                var tuple = context.Tuning.GetVariant<TunableTuple>("activity_selection", "enabled");
                if (ActivitiesOptional.HasItems())
                {
                    var list = tuple.Get<TunableList>("available_activities");
                    foreach(var activity in ElementTuning.GetInstanceKeys(ActivitiesOptional))
                    {
                        list.Set<TunableBasic>(null, activity.ToString());
                    }
                }
                if (ActivitiesRequired.HasItems())
                {
                    var list = tuple.GetVariant<TunableList>("required_activities", "enabled");
                    foreach (var activity in ElementTuning.GetInstanceKeys(ActivitiesRequired))
                    {
                        list.Set<TunableBasic>(null, activity.ToString());
                    }
                }
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);

            if (SuppressAutomaticBronzeTraits)
            {
                PythonBuilder.AddStep(SituationSuppressAutomaticBronzePythonStep.Current);
                SituationSuppressAutomaticBronzePythonStep.AddSituation((ulong)ElementTuning.GetSingleInstanceKey(Element));
            }

            if (DisguiseAsNonGoaledEvent)
            {
                // todo: tuning
                PythonBuilder.AddStep(SituationDisguiseAsNonGoaledPythonStep.Current);
                SituationDisguiseAsNonGoaledPythonStep.AddSituation((ulong)ElementTuning.GetSingleInstanceKey(Element));
            }
        }

        private void TuneScreenSlam(SituationExportContext context)
        {
            var tunableVariant1 = context.Tuning.Set<TunableVariant>("screen_slam_bronze", "enabled");
            var tunableVariant2 = tunableVariant1.Set<TunableVariant>("enabled", "reference");
            tunableVariant2.Set<TunableBasic>("reference", "75362");
            var tunableVariant3 = context.Tuning.Set<TunableVariant>("screen_slam_gold", "enabled");
            var tunableVariant4 = tunableVariant3.Set<TunableVariant>("enabled", "reference");
            tunableVariant4.Set<TunableBasic>("reference", "75364");
            var tunableVariant5 = context.Tuning.Set<TunableVariant>("screen_slam_no_medal", "enabled");
            var tunableVariant6 = tunableVariant5.Set<TunableVariant>("enabled", "reference");
            tunableVariant6.Set<TunableBasic>("reference", "75361");
            var tunableVariant7 = context.Tuning.Set<TunableVariant>("screen_slam_silver", "enabled");
            var tunableVariant8 = tunableVariant7.Set<TunableVariant>("enabled", "reference");
            tunableVariant8.Set<TunableBasic>("reference", "75363");
        }
    }
}