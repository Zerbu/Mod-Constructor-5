using Constructor5.Core;

namespace Constructor5.ZoneDirectorTemplates
{
    [XmlSerializerExtraType]
    public class ScheduledShiftSpawnTime
    {
        public int MaxAmount { get; set; } = 1;
        public int MinAmount { get; set; }
        public int StartHour { get; set; }
    }
}