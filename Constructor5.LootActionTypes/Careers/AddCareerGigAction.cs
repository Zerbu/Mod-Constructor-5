using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.LootActionSets;
using Constructor5.LootActionTypes.ExtendedSupport;

namespace Constructor5.LootActionTypes.Careers
{
    [SelectableObjectType("LootActionTypes", "CareersAddCareerGig")]
    [XmlSerializerExtraType]
    public class AddCareerGigAction : ExtendedSupportLootAction
    {
        public AddCareerGigAction() => GeneratedLabel = "Add Career Gig";

        [AutoTuneComplexChance]
        public ComplexChance Chance { get; set; } = new ComplexChance();

        public Reference CustomerFilter { get; set; } = new Reference();

        public Reference Gig { get; set; } = new Reference();

        protected override void TuneLootContent(LASExportContext originalContext, TuningHeader tuning)
        {
            var tunableVariant1 = originalContext.LootListTunable.Set<TunableVariant>(null, "add_career_gig");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("add_career_gig");
            tunableTuple1.Set<TunableBasic>("career_gig", Gig);

            if (ElementTuning.GetSingleInstanceKey(CustomerFilter) != null)
            {
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("gig_customer_filter", "enabled");
                tunableVariant2.Set<TunableBasic>("enabled", CustomerFilter);
            }
        }
    }
}