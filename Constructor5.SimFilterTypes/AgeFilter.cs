using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.SimFilters;
using Constructor5.Core;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "Age Filter")]
    [XmlSerializerExtraType]
    public class AgeFilter : SimFilterTerm
    {
        public AgeFilter() => GeneratedLabel = "Age Filter";

        public AgeFilterAges IdealAge { get; set; } = AgeFilterAges.ADULT;
        public AgeFilterAges MaximumAge { get; set; } = AgeFilterAges.ELDER;
        public AgeFilterAges MinimumAge { get; set; } = AgeFilterAges.CHILD;

        protected override void OnExport(TunableList filterTermsTunable)
        {
            var tunableVariant1 = filterTermsTunable.Set<TunableVariant>(null, "age");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("age");
            tunableTuple1.Set<TunableEnum>("ideal_value", IdealAge.ToString());
            tunableTuple1.Set<TunableEnum>("max_value", MaximumAge.ToString());
            tunableTuple1.Set<TunableEnum>("min_value", MinimumAge.ToString());
        }
    }
}