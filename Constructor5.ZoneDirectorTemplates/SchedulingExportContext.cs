using System.Collections.Generic;

namespace Constructor5.ZoneDirectorTemplates
{
    public class SchedulingExportContext
    {
        public List<MergedShiftSet> MergedShiftSets { get; } = new List<MergedShiftSet>();

        public MergedShiftSet GetMergedShiftSet(ScheduledShift shift)
        {
            var canMerge = false; //!shift.ObjectBasedMultiplier;

            if (canMerge)
            {
                foreach (var shiftSet in MergedShiftSets)
                {
                    if (
                        shiftSet.CanMerge &&
                        shift.Allow0Sunday && shiftSet.Allow0Sunday
                        && shift.Allow1Monday && shiftSet.Allow1Monday
                        && shift.Allow2Tuesday && shiftSet.Allow2Tuesday
                        && shift.Allow3Wednesday && shiftSet.Allow3Wednesday
                        && shift.Allow4Thursday && shiftSet.Allow4Thursday
                        && shift.Allow5Friday && shiftSet.Allow5Friday
                        && shift.Allow6Saturday && shiftSet.Allow6Saturday
                        && shift.Overlap
                    )
                    {
                        if (!shiftSet.IncludedShifts.Contains(shift))
                        {
                            shiftSet.IncludedShifts.Add(shift);
                        }
                        return shiftSet;
                    }
                }
            }

            var newSet = new MergedShiftSet
            {
                Allow0Sunday = shift.Allow0Sunday,
                Allow1Monday = shift.Allow1Monday,
                Allow2Tuesday = shift.Allow2Tuesday,
                Allow3Wednesday = shift.Allow3Wednesday,
                Allow4Thursday = shift.Allow4Thursday,
                Allow5Friday = shift.Allow5Friday,
                Allow6Saturday = shift.Allow6Saturday,
                CanMerge = canMerge,
                Overlap = shift.Overlap
            };
            newSet.IncludedShifts.Add(shift);
            MergedShiftSets.Add(newSet);
            return newSet;
        }

        public class MergedShiftSet
        {
            public bool Allow0Sunday { get; set; } = true;
            public bool Allow1Monday { get; set; } = true;
            public bool Allow2Tuesday { get; set; } = true;
            public bool Allow3Wednesday { get; set; } = true;
            public bool Allow4Thursday { get; set; } = true;
            public bool Allow5Friday { get; set; } = true;
            public bool Allow6Saturday { get; set; } = true;
            public bool CanMerge { get; set; }
            public List<ScheduledShift> IncludedShifts { get; } = new List<ScheduledShift>();
            public bool Overlap { get; set; }
        }
    }
}
