using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

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

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "trait_add");
            AutoTunerInvoker.Invoke(this, mainTuple);
            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");
        }
    }
}
