using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.TestConditionTypes.Collections
{
    [SelectableObjectType("ObjectiveConditionTypes", "CollectedSingleItemCondition")]
    [XmlSerializerExtraType]
    public class CollectedSingleItemObjectiveCondition : CollectedSingleItemCondition
    {
        protected override string GetVariantTunableName(string contextTag = null) => "collected_item_test";
    }
}
