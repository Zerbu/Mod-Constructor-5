using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using Constructor5.Base.SelectableObjects;

namespace Constructor5.LootActionTypes.Traits
{
    [SelectableObjectType("LootActionTypes", "TraitsRemoveTrait")]
    [XmlSerializerExtraType]
    public class RemoveTraitAction : LootAction
    {
        public RemoveTraitAction() => GeneratedLabel = "Remove Trait";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public string Participant { get; set; }
        public Reference Trait { get; set; } = new Reference();

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "trait_remove");

            var tunableVariant1 = mainTuple.Set<TunableVariant>("trait", "specific_trait");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("specific_trait");
            tunableTuple1.Set<TunableBasic>("specific_trait", Trait);

            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");
        }
    }
}