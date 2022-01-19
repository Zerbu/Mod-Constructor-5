using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [SelectableObjectType("BroadcasterEffects", "Run Loot Action Sets on Sender")]
    [XmlSerializerExtraType]
    public class BroadcasterSelfLootEffect : BroadcasterEffect
    {
        public BroadcasterSelfLootEffect() => GeneratedLabel = "Run Loot Action Sets on Sender";

        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        [AutoTuneTupleRange("broadcastee_count_interval", UpperDefaultOverride = int.MaxValue)]
        public IntBounds RequiredReceiversRange { get; set; } = new IntBounds(false, false, 1, 1);

        protected internal override void OnExport(BroadcasterExportContext originalContext)
        {
            var tunableVariant1 = originalContext.EffectListTunable.Set<TunableVariant>(null, "self_loot");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("self_loot");
            var tunableList1 = tunableTuple1.Get<TunableList>("loot_list");

            foreach (var loot in ElementTuning.GetInstanceKeys(LootActionSets))
            {
                tunableList1.Set<TunableBasic>(null, loot);
            }

            TestConditionTuning.TuneTestList(tunableTuple1, originalContext.TestConditions, "tests");
        }
    }
}