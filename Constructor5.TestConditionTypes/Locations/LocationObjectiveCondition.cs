using Constructor5.Base.SelectableObjects;

namespace Constructor5.TestConditionTypes.Locations
{
    [SelectableObjectType("ObjectiveConditionTypes", "LocationCondition")]
    public class LocationObjectiveCondition : LocationCondition
    {
        protected override string GetVariantTunableName() => "location_test";
    }
}
