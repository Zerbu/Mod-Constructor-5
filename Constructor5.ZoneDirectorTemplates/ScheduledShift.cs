using Constructor5.Base.ElementSystem;
using System.Collections.ObjectModel;

namespace Constructor5.ZoneDirectorTemplates
{
    public class ScheduledShift
    {
        public bool Allow0Sunday { get; set; } = true;
        public bool Allow1Monday { get; set; } = true;
        public bool Allow2Tuesday { get; set; } = true;
        public bool Allow3Wednesday { get; set; } = true;
        public bool Allow4Thursday { get; set; } = true;
        public bool Allow5Friday { get; set; } = true;
        public bool Allow6Saturday { get; set; } = true;
        public string Label { get; set; } = "Shift";
        public ObservableCollection<string> ObjectBasedMultiplierTags { get; set; } = new ObservableCollection<string>();
        public bool ObjectBasedMultiplier { get; set; }
        public int StartObjectBasedMultiplierFrom { get; set; } = 1;
        public int ObjectBasedMultiplierIterations { get; set; } = 1;
        public int ObjectBasedMultiplierMax { get; set; } = 10;
        public bool Overlap { get; set; }
        public ObservableCollection<ScheduledShiftSpawnTime> SpawnTimes { get; } = new ObservableCollection<ScheduledShiftSpawnTime>();
        public ReferenceList Situations { get; set; } = new ReferenceList();
    }
}