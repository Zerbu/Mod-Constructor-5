using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Collections
{
    [SelectableObjectType("SituationGoalConditionTypes", "Collection Condition")]
    [XmlSerializerExtraType]
    public class CollectionSituationGoalCondition : CollectionCondition
    {
        protected override string GetVariantTunableName() => "collection";
    }
}
