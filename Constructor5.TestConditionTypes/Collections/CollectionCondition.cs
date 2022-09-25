using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
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
    [SelectableObjectType("TestConditionTypes", "CollectionCondition")]
    [SelectableObjectType("ObjectiveConditionTypes", "CollectionCondition")]
    [XmlSerializerExtraType]
    public class CollectionCondition : TestCondition
    {
        public CollectionCondition() => GeneratedLabel = "Collection Condition";

        [AutoTuneEnum("collection_type")]
        public string CollectionType { get; set; } = "Unidentified";

        [AutoTuneIfTrue("complete_collection")]
        public bool RequireCollectionToBeComplete { get; set; }

        public Threshold Threshold { get; set; } = new Threshold();

        [AutoTuneEnum("who")]
        public string Participant { get; set; }

        protected override string GetVariantTunableName(string contextTag = null) => "collection_test";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());
            AutoTunerInvoker.Invoke(this, tupleTunable);

            if (!RequireCollectionToBeComplete)
            {
                AutoTuneThresholdTuple.TuneThresholdTuple(tupleTunable, Threshold, "threshold");
            }
        }
    }
}
