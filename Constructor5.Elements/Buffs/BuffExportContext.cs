using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using System.Collections.Generic;

namespace Constructor5.Elements.Buffs
{
    public class BuffExportContext
    {
        public BuffExportContext() { }

        public List<ulong> CommodityKeysToAdd { get; } = new List<ulong>();
        public BuffComponent CurrentComponent { get; set; }
        public Element Element { get; set; }
        public Dictionary<string, TuningHeader> IntervalCommodities { get; } = new Dictionary<string, TuningHeader>();
        public TuningBase Tuning { get; set; }
    }
}
