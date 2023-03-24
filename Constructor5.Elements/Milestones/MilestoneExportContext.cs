using Constructor5.Base.ExportSystem.Tuning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.Milestones
{
    public class MilestoneExportContext
    {
        public Milestone Element { get; set; }
        public TuningBase Tuning { get; set; }
        public int SimDataOffset { get; set; }
        public int SimDataAgesPosition { get; set; }
    }
}
