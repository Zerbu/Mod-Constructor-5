using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "Is Active Household Filter")]
    [XmlSerializerExtraType]
    public class IsActiveHouseholdFilter : InvertOnlyFilter
    {
        public IsActiveHouseholdFilter() => GeneratedLabel = "Is Active Household Filter";

        protected override string GetVariantName() => "in_family";
    }
}
