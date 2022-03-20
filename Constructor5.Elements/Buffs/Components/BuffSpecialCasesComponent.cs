using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    public class BuffSpecialCasesComponent : BuffComponent
    {
        public override string ComponentLabel => "SpecialCases";

        [AutoTuneIfTrue("show_timeout", "False")]
        public bool HideTimeout { get; set; }

        [AutoTuneIfTrue("is_npc_only")]
        public bool IsNPCOnly { get; set; }

        [AutoTuneIfTrue("refresh_on_add", "False")]
        public bool NoRefreshOnAdd { get; set; }

        public TestConditionList ProximityConditions { get; set; } = new TestConditionList();
        public STBLString ProximityReason { get; set; } = new STBLString();

        [AutoTuneBasic("timeout_string")]
        public STBLString TimeoutStringOverride { get; set; } = new STBLString();

        protected internal override bool HasContent() => true;

        protected internal override void OnExport(BuffExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            if (!string.IsNullOrEmpty(ProximityReason.CustomText))
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("proximity_buff_added_reason", "proximity_add_reason");
                tunableVariant1.Set<TunableBasic>("proximity_add_reason", ProximityReason);
            }

            var proximityConditions = new List<TestCondition>();
            foreach (var condition in ProximityConditions)
            {
                proximityConditions.Add(condition.Condition);
            }

            if (proximityConditions.Count > 0)
            {
                var tunableVariant2 = context.Tuning.Set<TunableVariant>("proximity_detection_tests", "proximity_tests");
                TestConditionTuning.TuneTestList(tunableVariant2, proximityConditions, "proximity_tests");
            }
        }
    }
}