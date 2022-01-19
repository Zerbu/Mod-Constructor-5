using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;

namespace Constructor5.Elements.Broadcasters
{
    public class BroadcasterExportContext
    {
        public BroadcasterExportContext()
        { }

        public BroadcasterExportContext(BroadcasterExportContext copyFrom)
        {
            EffectListTunable = copyFrom.EffectListTunable;
            TestConditions.AddRange(copyFrom.TestConditions);
        }

        public TunableList EffectListTunable { get; set; }
        public List<TestCondition> TestConditions { get; } = new List<TestCondition>();
    }
}