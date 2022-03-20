using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.LootActionSets;

namespace Constructor5.LootActionTypes.ExtendedSupport
{
    [SelectableObjectType("LootActionTypes", "ExtendedSupportRunOtherActionSets")]
    [XmlSerializerExtraType]
    public class RunOtherActionSets : ExtendedSupportLootAction
    {
        public RunOtherActionSets() => GeneratedLabel = "Run Other Action Sets";

        public ReferenceList ActionSets { get; set; } = new ReferenceList();

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        protected override void TuneLootContent(LASExportContext originalContext, TuningHeader tuning)
        {
            foreach (var actionSet in ElementTuning.GetInstanceKeys(ActionSets))
            {
                var tunableVariant1 = originalContext.LootListTunable.Set<TunableVariant>(null, "actions");
                tunableVariant1.Set<TunableBasic>("actions", actionSet);
            }
        }
    }
}