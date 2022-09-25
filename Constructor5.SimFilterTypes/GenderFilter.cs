using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.SimFilters;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "GenderFilter")]
    [XmlSerializerExtraType]
    public class GenderFilter : SimFilterTerm
    {
        public GenderFilter() => GeneratedLabel = "Gender Filter";

        public GenderFilterGenders Gender { get; set; } = GenderFilterGenders.MALE;

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "gender");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("gender");
            tunableTuple1.Set<TunableEnum>("gender", Gender.ToString());
        }
    }
}
