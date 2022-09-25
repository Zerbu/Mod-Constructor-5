using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public class BasicExtraExportContext
    {
        public BasicExtraExportContext()
        { }

        public BasicExtraExportContext(BasicExtraExportContext copyFrom)
        {
            TestConditions.AddRange(copyFrom.TestConditions);
            BasicExtrasListTunable = copyFrom.BasicExtrasListTunable;
        }

        public TunableList BasicExtrasListTunable { get; set; }
        public List<TestCondition> TestConditions { get; } = new List<TestCondition>();
    }
}