using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.SituationGoalTemplates.Single
{
    public abstract class SituationGoalTargetedBase : SituationGoalTemplate
    {
        public bool InSituationOnly { get; set; }
        public ObservableCollection<string> RoleTags { get; } = new ObservableCollection<string>();
        public SituationGoalInteractionTarget SpecificTarget { get; set; }
        public ObservableCollection<TestConditionListItem> TargetConditions { get; set; } = new ObservableCollection<TestConditionListItem>();

        protected void TuneTarget(SituationGoalExportContext context)
        {
            var conditions = new List<TestCondition>();
            foreach (var condition in TargetConditions)
            {
                conditions.Add(condition.Condition);
            }
            TestConditionTuning.TuneTestConditions(context.Tuning, conditions, "_target_tests");

            context.Tuning.Set<TunableBasic>("_select_all_instantiated_sims", "True");

            switch (SpecificTarget)
            {
                case SituationGoalInteractionTarget.Random:
                    context.Tuning.Set<TunableEnum>("_target_option", "GoalSystemChoice");
                    break;

                case SituationGoalInteractionTarget.Inherited:
                    context.Tuning.Set<TunableEnum>("_target_option", "Inherited");
                    break;

                case SituationGoalInteractionTarget.RandomExcludingInherited:
                    context.Tuning.Set<TunableEnum>("_target_option", "GoalSystemChoiceExcludingInherited");
                    break;
            }

            if (RoleTags.Count > 0)
            {
                TuneRoleTags(context);
            }
        }

        private void TuneRoleTags(SituationGoalExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("_target_tests");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "situation_job");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("situation_job");
            var tunableList2 = tunableTuple1.Get<TunableList>("role_tags");
            foreach (var tag in RoleTags)
            {
                tunableList2.Set<TunableEnum>(null, tag);
            }
        }
    }
}