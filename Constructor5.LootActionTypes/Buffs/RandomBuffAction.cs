using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.TestConditionTypes.Buffs;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Buffs
{
    [SelectableObjectType("LootActionTypes", "BuffsAddRandomBuff")]
    [XmlSerializerExtraType]
    public class RandomBuffAction : LootAction
    {
        public RandomBuffAction() => GeneratedLabel = "Add Random Buff";

        public ReferenceList Buffs { get; set; } = new ReferenceList();

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public bool IgnoreIfAlreadyHasBuff { get; set; } = true;

        [AutoTuneEnum("subject")]
        public string Participant { get; set; }

        public STBLString Reason { get; set; } = new STBLString();

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "dynamic_buff_loot");

            AutoTunerInvoker.Invoke(this, mainTuple);

            foreach(var buff in Buffs.GetOfType<WeightedBuffReferenceListItem>())
            {
                var tunableList1 = mainTuple.Get<TunableList>("buffs");
                foreach (var key in ElementTuning.GetInstanceKeys(buff.Reference))
                {
                    var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                    tunableTuple1.Set<TunableBasic>("key", key);
                    if (buff.Weight != 1)
                    {
                        tunableTuple1.Set<TunableBasic>("value", buff.Weight);
                    }
                }
            }

            var tunableVariant1 = mainTuple.Set<TunableVariant>("buff_reason", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", Reason);

            var newContext = new LASExportContext(originalContext);

            if (IgnoreIfAlreadyHasBuff)
            {
                var buffCondition = new BuffCondition();
                foreach (var buff in Buffs.GetOfType<WeightedBuffReferenceListItem>())
                {
                    buffCondition.Blacklist.Items.Add(new ReferenceListItem
                    {
                        Reference = buff.Reference
                    });
                }
                newContext.TestConditions.Add(buffCondition);
            }

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }
    }
}
