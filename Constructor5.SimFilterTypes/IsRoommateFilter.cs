using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.SimFilterTypes
{
    [SelectableObjectType("SimFilterTypes", "IsRoommateFilter")]
    [XmlSerializerExtraType]
    public class IsRoommateFilter : InvertOnlyFilter
    {
        public IsRoommateFilter() => GeneratedLabel = "Is Roommate Filter";

        protected override string GetVariantName() => "is_roommate";
    }
}
