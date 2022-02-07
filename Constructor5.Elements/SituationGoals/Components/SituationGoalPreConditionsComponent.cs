﻿using Constructor5.Elements.TestConditions;
using Constructor5.UI.AutoGeneratedEditors;
using Constructor5.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.SituationGoals.Components
{
    [XmlSerializerExtraType]
    [HasAutoEditor("AvailabilityConditionsNotice")]
    public class SituationGoalPreConditionsComponent : SituationGoalComponent
    {
        public override string ComponentLabel => "AvailabilityConditions";

        [AutoEditorConditionList]
        public ObservableCollection<TestConditionListItem> Conditions { get; set; } = new ObservableCollection<TestConditionListItem>();

        protected internal override void OnExport(SituationGoalExportContext context)
        {
            var conditions = new List<TestCondition>();
            foreach (var condition in Conditions)
            {
                conditions.Add(condition.Condition);
            }

            TestConditionTuning.TuneTestConditions(context.Tuning, conditions, "_pre_tests");
        }
    }
}
