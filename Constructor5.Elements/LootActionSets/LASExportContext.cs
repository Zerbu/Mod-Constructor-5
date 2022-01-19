using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;

namespace Constructor5.Elements.LootActionSets
{
    public class LASExportContext
    {
        public LASExportContext()
        { }

        public LASExportContext(LASExportContext copyFrom)
        {
            LootListTunable = copyFrom.LootListTunable;
            TestConditions.AddRange(copyFrom.TestConditions);
        }

        public LootActionSet Element { get; set; }
        public TunableList LootListTunable { get; set; }
        public List<TestCondition> TestConditions { get; } = new List<TestCondition>();
    }
}