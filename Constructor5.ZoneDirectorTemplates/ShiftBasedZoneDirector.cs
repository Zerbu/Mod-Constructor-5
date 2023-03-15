using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using Constructor5.Elements.ZoneDirectors;
using System.Collections.ObjectModel;

namespace Constructor5.ZoneDirectorTemplates
{
    [SelectableObjectType("ZoneDirectorTemplates", "ShiftBasedZoneDirector")]
    [XmlSerializerExtraType]
    public class ShiftBasedZoneDirector : ZoneDirectorTemplate
    {
        public override string Label => "Shift-Based Zone Director";

        public ObservableCollection<ScheduledShift> Shifts { get; } = new ObservableCollection<ScheduledShift>();

        protected override void OnExport(ZoneDirectorExportContext context)
        {
            var additionalContext = new SchedulingExportContext();
            foreach (var shift in Shifts)
            {
                additionalContext.GetMergedShiftSet(shift);
            }

            var tunableList1 = context.Tuning.Get<TunableList>("situation_shifts");
            foreach (var shift in additionalContext.MergedShiftSets)
            {
                TuneShift(context, shift, tunableList1);
            }
        }

        private void TuneObjectMultipliers(ScheduledShift shift, TunableTuple curveBased)
        {
            var tunableTuple1 = curveBased.Get<TunableTuple>("desired_sim_count_multipliers");
            var tunableList1 = tunableTuple1.Get<TunableList>("multipliers");

            void Tune(int objectAmount, int multiplierAmount)
            {
                if (multiplierAmount == 1)
                {
                    return;
                }

                var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
                tunableTuple2.Set<TunableBasic>("multiplier", multiplierAmount);
                var tunableList2 = tunableTuple2.Get<TunableList>("tests");
                var tunableList3 = tunableList2.Get<TunableList>(null);
                var tunableVariant1 = tunableList3.Set<TunableVariant>(null, "object_criteria");
                var tunableTuple3 = tunableVariant1.Get<TunableTuple>("object_criteria");
                var tunableVariant2 = tunableTuple3.Set<TunableVariant>("identity_test", "tags");
                var tunableTuple4 = tunableVariant2.Get<TunableTuple>("tags");
                var tunableList4 = tunableTuple4.Get<TunableList>("tag_set");

                foreach (string tag in shift.ObjectBasedMultiplierTags)
                {
                    tunableList4.Set<TunableEnum>(null, tag);
                }

                tunableTuple3.Set<TunableBasic>("on_active_lot", "True");
                tunableTuple3.Set<TunableBasic>("owned", "False");
                var tunableVariant3 = tunableTuple3.Set<TunableVariant>("subject_specific_tests", "all_objects");
                var tunableTuple5 = tunableVariant3.Get<TunableTuple>("all_objects");
                var tunableTuple6 = tunableTuple5.Get<TunableTuple>("quantity");
                if (multiplierAmount == shift.ObjectBasedMultiplierMax)
                {
                    tunableTuple6.Set<TunableEnum>("comparison", "GREATER_OR_EQUAL");
                }
                else if (objectAmount == shift.StartObjectBasedMultiplierFrom-1)
                {
                    tunableTuple6.Set<TunableEnum>("comparison", "LESS_OR_EQUAL");
                }
                else
                {
                    tunableTuple6.Set<TunableEnum>("comparison", "EQUAL");
                }
                
                tunableTuple6.Set<TunableBasic>("value", objectAmount);
            }

            Tune(shift.StartObjectBasedMultiplierFrom-1, 0);

            var totalIndex = 1;
            for (int i = 1; i <= shift.ObjectBasedMultiplierMax; i++)
            {
                for (int instance = 1; instance <= shift.ObjectBasedMultiplierIterations; instance++)
                {
                    Tune(totalIndex + shift.StartObjectBasedMultiplierFrom-1, i);
                    totalIndex++;
                }
            }
        }

        private void TuneShift(ZoneDirectorExportContext context, SchedulingExportContext.MergedShiftSet shiftSet, TunableList shiftsList)
        {
            var shiftTuple = shiftsList.Get<TunableTuple>(null);

            var tunableVariant1 = shiftTuple.Set<TunableVariant>("shift_curve", "curve_based");
            var curveBased = tunableVariant1.Get<TunableTuple>("curve_based");

            var entriesList = curveBased.Get<TunableList>("entries");
            {
                var tunableTuple1 = entriesList.Get<TunableTuple>(null);
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("days_of_the_week");
                tunableTuple2.Set<TunableBasic>("0 SUNDAY", shiftSet.Allow0Sunday);
                tunableTuple2.Set<TunableBasic>("1 MONDAY", shiftSet.Allow1Monday);
                tunableTuple2.Set<TunableBasic>("2 TUESDAY", shiftSet.Allow2Tuesday);
                tunableTuple2.Set<TunableBasic>("3 WEDNESDAY", shiftSet.Allow3Wednesday);
                tunableTuple2.Set<TunableBasic>("4 THURSDAY", shiftSet.Allow4Thursday);
                tunableTuple2.Set<TunableBasic>("5 FRIDAY", shiftSet.Allow5Friday);
                tunableTuple2.Set<TunableBasic>("6 SATURDAY", shiftSet.Allow6Saturday);
                var tunableList1 = tunableTuple1.Get<TunableList>("walkby_desire_by_time_of_day");

                foreach (var shift in shiftSet.IncludedShifts)
                {
                    foreach (var spawnTime in shift.SpawnTimes)
                    {
                        var tunableTuple3 = tunableList1.Get<TunableTuple>(null);
                        tunableTuple3.Set<TunableBasic>("hour_of_day", spawnTime.StartHour);
                        var tunableTuple4 = tunableTuple3.Get<TunableTuple>("desired_walkby_situations");

                        if (spawnTime.MinAmount == spawnTime.MaxAmount)
                        {
                            var simCountVariant = tunableTuple4.Set<TunableVariant>("desired_sim_count", "literal");
                            var simCountTuple = simCountVariant.Get<TunableTuple>("literal");
                            simCountTuple.Set<TunableBasic>("value", spawnTime.MinAmount);
                        }
                        else
                        {
                            var simCountVariant = tunableTuple4.Set<TunableVariant>("desired_sim_count", "random_in_range");
                            var simCountTuple = simCountVariant.Get<TunableTuple>("random_in_range");
                            if (spawnTime.MinAmount != 0)
                            {
                                simCountTuple.Set<TunableBasic>("lower_bound", spawnTime.MinAmount);
                            }

                            simCountTuple.Set<TunableBasic>("upper_bound", spawnTime.MaxAmount);
                        }

                        var tunableList2 = tunableTuple4.Get<TunableList>("weighted_situations");

                        foreach (var situation in shift.Situations.GetOfType<ScheduledSituation>())
                        {
                            foreach (var situationKey in ElementTuning.GetInstanceKeys(situation.Reference))
                            {
                                var tunableTuple6 = tunableList2.Get<TunableTuple>(null);
                                tunableTuple6.Set<TunableBasic>("situation", situationKey);
                                if (situation.Weight != 1)
                                {
                                    tunableTuple6.Set<TunableBasic>("weight", situation.Weight);
                                }
                                TestConditionTuning.TuneTestList(tunableTuple6, situation.Conditions.ToConditionList(), "tests");
                            }
                        }
                    }

                    if (shift.ObjectBasedMultiplier)
                    {
                        TuneObjectMultipliers(shift, curveBased);
                    }
                }
            }

            if (shiftSet.Overlap)
            {
                shiftTuple.Set<TunableEnum>("shift_strictness", "OVERLAP");
            }        }
    }
}