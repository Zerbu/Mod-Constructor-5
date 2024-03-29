using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using System.Collections.ObjectModel;

namespace Constructor5.TestConditionTypes.Collections
{
    [SelectableObjectType("SituationGoalConditionTypes", "CollectedSingleItemCondition")]
    [XmlSerializerExtraType]
    public class CollectedSingleItemCondition : TestCondition
    {
        public CollectedSingleItemCondition() => GeneratedLabel = "Collected Single Item Condition";

        public ObservableCollection<string> CollectionTypes { get; set; } = new ObservableCollection<string>();

        protected override string GetVariantTunableName(string contextTag = null) => "collected_single_item";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());

            var tunableVariant1 = tupleTunable.Set<TunableVariant>("test_type", "collection_type");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("collection_type");
            var tunableList1 = tunableTuple1.Get<TunableList>("collection_types");
            foreach(var type in CollectionTypes)
            {
                tunableList1.Set<TunableEnum>(null, type);
            }
        }
    }
}
