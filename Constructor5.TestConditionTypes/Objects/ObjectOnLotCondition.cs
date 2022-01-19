using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.TestConditionTypes.Objects
{
    [SelectableObjectType("ObjectiveConditionTypes", "ObjectOnLotCondition")]
    [SelectableObjectType("TestConditionTypes", "ObjectOnLotCondition")]
    [XmlSerializerExtraType]
    public class ObjectOnLotCondition : TestCondition
    {
        public ObjectOnLotCondition() => GeneratedLabel = "Object On Lot Condition";

        [AutoTuneIfFalse("on_active_lot", "True")]
        public bool AllowPublicSpace { get; set; }

        public bool IsCraftable { get; set; }

        public bool MustBeCompleted { get; set; }

        [AutoTuneIfFalse("owned")]
        public bool MustBeOwnedByActiveHousehold { get; set; }

        public ObservableCollection<string> Tags { get; set; } = new ObservableCollection<string>();

        public Threshold Quantity { get; set; } = new Threshold();
        public bool RestrictSimoleonValue { get; set; }

        public Threshold SimoleonValue { get; set; } = new Threshold();

        protected override string GetVariantTunableName() => "object_criteria";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tuple = variantTunable.Get<TunableTuple>("object_criteria");

            if (Quantity.Amount > 1 || Quantity.Comparison != ThresholdComparison.GREATER_OR_EQUAL)
            {
                var tunableVariant1 = tuple.Set<TunableVariant>("subject_specific_tests", "all_objects");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("all_objects");

                AutoTuneThresholdTuple.TuneThresholdTuple(tunableTuple1, Quantity, "quantity");
            }

            if (RestrictSimoleonValue)
            {
                var tunableVariant1 = tuple.Set<TunableVariant>("subject_specific_tests", "all_objects");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("all_objects");
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("total_value", "enabled");
                AutoTuneThresholdTuple.TuneThresholdTuple(tunableVariant2, SimoleonValue, "enabled");
            }

            if (IsCraftable)
            {
                var tunableList1 = tuple.Get<TunableList>("test_events");
                tunableList1.Set<TunableEnum>(null, "ItemCrafted");
                tunableList1.Set<TunableEnum>(null, "OnInventoryChanged");
                tunableList1.Set<TunableEnum>(null, "OnExitBuildBuy");

                tuple.Set<TunableBasic>("completed", "True");
            }

            if (Tags.Count > 0)
            {
                var tunableVariant1 = tuple.Set<TunableVariant>("identity_test", "tags");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("tags");
                var tunableList1 = tunableTuple1.Get<TunableList>("tag_set");
                foreach(var tag in Tags)
                {
                    tunableList1.Set<TunableEnum>(null, tag);
                }
            }

            AutoTunerInvoker.Invoke(this, tuple);
        }
    }
}