using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.Elements.Broadcasters.Effects
{
    [SelectableObjectType("BroadcasterEffects", "Run Loot Action Sets on Receiver")]
    [XmlSerializerExtraType]
    public class BroadcasterLootEffect : BroadcasterEffect
    {
        public BroadcasterLootEffect() => GeneratedLabel = "Run Loot Action Sets on Receiver";

        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        protected internal override void OnExport(BroadcasterExportContext originalContext)
        {
            var tunableVariant1 = originalContext.EffectListTunable.Set<TunableVariant>(null, "loot");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("loot");
            var tunableList1 = tunableTuple1.Get<TunableList>("loot_list");

            foreach(var loot in ElementTuning.GetInstanceKeys(LootActionSets))
            {
                tunableList1.Set<TunableBasic>(null, loot);
            }

            TestConditionTuning.TuneTestList(tunableTuple1, originalContext.TestConditions, "tests");
        }
    }
}
