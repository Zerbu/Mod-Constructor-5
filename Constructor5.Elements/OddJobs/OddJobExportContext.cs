using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using System.Collections.Generic;

namespace Constructor5.Elements.OddJobs
{
    public class OddJobExportContext
    {
        public OddJobExportContext() { }

        public OddJob Element { get; set; }
        public TuningBase Tuning { get; set; }
    }
}
