using Constructor5.Base.ExportSystem.Tuning;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Constructor5.Elements.TestConditions
{
    public static class TestConditionTuning
    {
        public static void TuneTestList(TuningBase tuning, IEnumerable<TestCondition> conditions, string tunableName)
        {
            var nonIgnoredConditions = conditions.Where(x => !(x is AlwaysRunCondition));

            if (nonIgnoredConditions.Count() == 0)
            {
                return;
            }

            var rootListTunable = tuning.Get<TunableList>(tunableName);
            var listTunable = rootListTunable.Get<TunableList>(null);

            foreach(var condition in nonIgnoredConditions)
            {
                condition.OnExportMain(listTunable);
            }
        }

        public static void TuneTestConditions(TuningBase tuning, IEnumerable<TestCondition> conditions, string listTunableName = null)
        {
            if (conditions.Count() == 0)
            {
                return;
            }

            Debug.Assert(listTunableName != null || tuning is TunableList);
            var listTunable = listTunableName != null ? tuning.Get<TunableList>(listTunableName) : tuning as TunableList;

            foreach (var condition in conditions)
            {
                condition.OnExportMain(listTunable);
            }
        }

        public static void TuneSingleTestCondition(TuningBase tuning, TestCondition condition, string tunableName)
        {
            condition.OnExportMain(tuning, tunableName);
        }
    }
}
