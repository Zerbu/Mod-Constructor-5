using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitSetupComponent : TraitComponent
    {
        public override string ComponentLabel => "SetupActions";

        public ReferenceList LootActionSets { get; set; } = new ReferenceList();

        protected internal override void OnExport(TraitExportContext context)
        {
            foreach (var action in ElementTuning.GetInstanceKeys(LootActionSets))
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("loot_on_trait_add", "enabled");
                var tunableList1 = tunableVariant1.Get<TunableList>("enabled");
                tunableList1.Set<TunableBasic>(null, action);
            }
        }
    }
}