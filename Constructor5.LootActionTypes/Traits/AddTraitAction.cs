using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using System;
using Constructor5.TestConditionTypes.Statistics;
using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.LootActionTypes.Traits
{
    [SelectableObjectType("LootActionTypes", "TraitsAddTrait")]
    [XmlSerializerExtraType]
    public class AddTraitAction : LootAction
    {
        public AddTraitAction() => GeneratedLabel = "Add Trait";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        [AutoTuneBasic("trait")]
        public Reference Trait { get; set; } = new Reference();

        [AutoTuneBasic("subject")]
        public string Participant { get; set; }

        public bool TreatAsSelfDiscovery { get; set; }

        protected override void OnExport(LASExportContext originalContext)
        {
            var newContext = new LASExportContext(originalContext);
            if (TreatAsSelfDiscovery)
            {
                TuneSelfDiscovery(newContext);
            }

            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "trait_add");
            AutoTunerInvoker.Invoke(this, mainTuple);

            TestConditionTuning.TuneTestList(mainTuple, newContext.TestConditions, "tests");
        }

        private void TuneSelfDiscovery(LASExportContext context)
        {
            {
                var tunableVariant1 = context.LootListTunable.Set<TunableVariant>(null, "statistics");
                var tunableVariant2 = tunableVariant1.Set<TunableVariant>("statistics", "statistic_change");
                var tunableTuple1 = tunableVariant2.Get<TunableTuple>("statistic_change");
                tunableTuple1.Set<TunableBasic>("amount", "1");
                tunableTuple1.Set<TunableBasic>("stat", "312122");
                var tunableList1 = tunableTuple1.Get<TunableList>("subject");
                tunableList1.Set<TunableEnum>(null, "Actor");
                var tunableVariant3 = context.LootListTunable.Set<TunableVariant>(null, "statistics");
                var tunableVariant4 = tunableVariant3.Set<TunableVariant>("statistics", "statistic_remove");
                var tunableTuple2 = tunableVariant4.Get<TunableTuple>("statistic_remove");
                tunableTuple2.Set<TunableBasic>("stat", "312122");
                var tunableList2 = tunableTuple2.Get<TunableList>("subject");
                tunableList2.Set<TunableEnum>(null, "Actor");
                var tunableList3 = tunableTuple2.Get<TunableList>("tests");
                var tunableList4 = tunableList3.Get<TunableList>(null);
                var tunableVariant5 = tunableList4.Set<TunableVariant>(null, "statistic");
                var tunableTuple3 = tunableVariant5.Get<TunableTuple>("statistic");
                tunableTuple3.Set<TunableBasic>("stat", "312122");
                var tunableVariant6 = tunableTuple3.Set<TunableVariant>("threshold", "value_threshold");
                var tunableTuple4 = tunableVariant6.Get<TunableTuple>("value_threshold");
                tunableTuple4.Set<TunableEnum>("comparison", "EQUAL");
                tunableTuple4.Set<TunableBasic>("value", "3");
                var tunableVariant7 = context.LootListTunable.Set<TunableVariant>(null, "statistics");
                var tunableVariant8 = tunableVariant7.Set<TunableVariant>("statistics", "statistic_remove");
                var tunableTuple5 = tunableVariant8.Get<TunableTuple>("statistic_remove");
                tunableTuple5.Set<TunableBasic>("stat", "306831");
                var tunableList5 = tunableTuple5.Get<TunableList>("subject");
                tunableList5.Set<TunableEnum>(null, "Actor");
                var tunableVariant9 = context.LootListTunable.Set<TunableVariant>(null, "buff");
                var tunableTuple6 = tunableVariant9.Get<TunableTuple>("buff");
                var tunableTuple7 = tunableTuple6.Get<TunableTuple>("buff");
                tunableTuple7.Set<TunableBasic>("buff_type", "318344");
                var tunableVariant10 = context.LootListTunable.Set<TunableVariant>(null, "actions");
                tunableVariant10.Set<TunableBasic>("actions", "334974");

                var tunableVariant33 = context.LootListTunable.Set<TunableVariant>(null, "buff");
                var tunableTuple18 = tunableVariant33.Get<TunableTuple>("buff");
                var tunableTuple19 = tunableTuple18.Get<TunableTuple>("buff");
                tunableTuple19.Set<TunableBasic>("buff_type", "313002");
                var tunableVariant34 = context.LootListTunable.Set<TunableVariant>(null, "reaction");
                var tunableTuple20 = tunableVariant34.Get<TunableTuple>("reaction");
                var tunableVariant35 = tunableTuple20.Set<TunableVariant>("si_reaction", "enabled");
                var tunableTuple21 = tunableVariant35.Get<TunableTuple>("enabled");
                tunableTuple21.Set<TunableBasic>("affordance", "313892");
                var tunableVariant36 = tunableTuple21.Set<TunableVariant>("affordance_target", "disabled");
                var tunableVariant37 = context.LootListTunable.Set<TunableVariant>(null, "notification_and_dialog");
                var tunableTuple22 = tunableVariant37.Get<TunableTuple>("notification_and_dialog");
                var tunableVariant38 = tunableTuple22.Set<TunableVariant>("dialog", "notification");
                var tunableTuple23 = tunableVariant38.Get<TunableTuple>("notification");
                var tunableVariant39 = tunableTuple23.Set<TunableVariant>("icon", "enabled");
                var tunableVariant40 = tunableVariant39.Set<TunableVariant>("enabled", "participant");
                var tunableVariant41 = tunableTuple23.Set<TunableVariant>("text", "single");
                tunableVariant41.Set<TunableBasic>("single", "0x9214962D");
                var tunableVariant42 = tunableTuple23.Set<TunableVariant>("text_tokens", "enabled");
                var tunableTuple24 = tunableVariant42.Get<TunableTuple>("enabled");
                var tunableList16 = tunableTuple24.Get<TunableList>("tokens");
                var tunableVariant43 = tunableList16.Set<TunableVariant>(null, "participant_type");
                var tunableList17 = tunableTuple22.Get<TunableList>("tests");
                var tunableList18 = tunableList17.Get<TunableList>(null);
                var tunableVariant44 = tunableList18.Set<TunableVariant>(null, "trait");
                var tunableTuple25 = tunableVariant44.Get<TunableTuple>("trait");
                var tunableList19 = tunableTuple25.Get<TunableList>("whitelist_traits");
                tunableList19.Set<TunableBasic>(null, "315699");
            }
            {
                var tunableVariant1 = context.LootListTunable.Set<TunableVariant>(null, "trait_add");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("trait_add");
                var tunableList1 = tunableTuple1.Get<TunableList>("tests");
                var tunableList2 = tunableList1.Get<TunableList>(null);
                var tunableVariant2 = tunableList2.Set<TunableVariant>(null, "statistic");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("statistic");
                tunableTuple2.Set<TunableBasic>("stat", "312122");
                var tunableVariant3 = tunableTuple2.Set<TunableVariant>("threshold", "value_threshold");
                var tunableTuple3 = tunableVariant3.Get<TunableTuple>("value_threshold");
                tunableTuple3.Set<TunableEnum>("comparison", "EQUAL");
                tunableTuple3.Set<TunableBasic>("value", "3");
                tunableTuple1.Set<TunableBasic>("trait", "315699");
            }
        }
    }
}
