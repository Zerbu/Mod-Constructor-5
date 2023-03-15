using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;
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

        public Reference TemporaryTrait { get; set; } = new Reference();

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

            if (ElementTuning.GetSingleInstanceKey(TemporaryTrait) != null)
            {
                var addLoot = TuneTemporaryTraitAddLoot(context);
                context.Tuning.Get<TunableList>("_loot_on_instance").Set<TunableBasic>(null, addLoot);
                context.Tuning.Get<TunableList>("_loot_on_addition").Set<TunableBasic>(null, addLoot);
                context.Tuning.Get<TunableList>("_loot_on_removal").Set<TunableBasic>(null, TuneTemporaryTraitRemoveLoot(context));
            }
        }

        private ulong TuneTemporaryTraitRemoveLoot(BuffExportContext context)
        {
            var tuning = ElementTuning.Create(context.Element, "TemporaryTraitRemoveLoot");
            tuning.Class = "LootActions";
            tuning.InstanceType = "action";
            tuning.Module = "interactions.utils.loot";

            var lootList = tuning.Get<TunableList>("loot_actions");

            var tunableVariant1 = lootList.Set<TunableVariant>(null, "trait_remove");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("trait_remove");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("trait", "specific_trait");
            var tunableTuple2 = tunableVariant2.Get<TunableTuple>("specific_trait");
            tunableTuple2.Set<TunableBasic>("specific_trait", ElementTuning.GetSingleInstanceKey(TemporaryTrait));

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }

        private ulong TuneTemporaryTraitAddLoot(BuffExportContext context)
        {
            var tuning = ElementTuning.Create(context.Element, "TemporaryTraitAddLoot");
            tuning.Class = "LootActions";
            tuning.InstanceType = "action";
            tuning.Module = "interactions.utils.loot";

            var lootList = tuning.Get<TunableList>("loot_actions");

            var tunableVariant1 = lootList.Set<TunableVariant>(null, "trait_add");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("trait_add");
            tunableTuple1.Set<TunableBasic>("trait", ElementTuning.GetSingleInstanceKey(TemporaryTrait));

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}