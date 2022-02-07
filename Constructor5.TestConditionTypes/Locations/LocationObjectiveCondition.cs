using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Locations
{
    [SelectableObjectType("ObjectiveConditionTypes", "LocationCondition")]
    [XmlSerializerExtraType]
    public class LocationObjectiveCondition : LocationCondition
    {
        protected override string GetVariantTunableName() => "location_test";
    }
}
