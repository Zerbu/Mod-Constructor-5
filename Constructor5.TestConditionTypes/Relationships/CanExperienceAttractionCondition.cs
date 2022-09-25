using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Relationships
{
    [SelectableObjectType("TestConditionTypes", "CanExperienceAttractionCondition", Description = "CanExperienceAttractionConditionDescription")]
    [XmlSerializerExtraType]
    public class CanExperienceAttractionCondition : TestCondition
    {
        public CanExperienceAttractionCondition() => GeneratedLabel = "Can Experience Romantic Attraction Condition";

        protected override string GetVariantTunableName(string contextTag = null) => null;

        protected override void OnExportMain(TuningBase tunable, string tunableName = null, string contextTag = null)
        {
            var tunableVariant1 = tunable.Set<TunableVariant>(null, "sim_info");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("sim_info");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("ages", "specified");
            var tunableVariant3 = tunableTuple1.Set<TunableVariant>("species", "specified");
            var tunableTuple2 = tunableVariant3.Get<TunableTuple>("specified");
            var tunableList1 = tunableTuple2.Get<TunableList>("species");
            tunableList1.Set<TunableEnum>(null, String.Empty);
            var tunableVariant4 = tunable.Set<TunableVariant>(null, "trait");
            var tunableTuple3 = tunableVariant4.Get<TunableTuple>("trait");
            var tunableList2 = tunableTuple3.Get<TunableList>("whitelist_traits");
            tunableList2.Set<TunableBasic>(null, "276492");
            tunableList2.Set<TunableBasic>(null, "276493");
            tunableList2.Set<TunableBasic>(null, "276496");
        }

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
        }
    }
}
