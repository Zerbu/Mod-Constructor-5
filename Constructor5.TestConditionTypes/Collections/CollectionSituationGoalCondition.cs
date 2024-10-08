using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.TestConditionTypes.Collections
{
    [SelectableObjectType("SituationGoalConditionTypes", "CollectionCondition")]
    [XmlSerializerExtraType]
    public class CollectionSituationGoalCondition : CollectionCondition
    {
        protected override string GetVariantTunableName(string contextTag = null) => "collection";
    }
}
