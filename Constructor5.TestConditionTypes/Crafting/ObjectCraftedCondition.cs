using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.TestConditionTypes.Crafting
{
    [SelectableObjectType("ObjectiveConditionTypes", "ObjectCraftedCondition")]
    [XmlSerializerExtraType]
    public class ObjectCraftedCondition : TestCondition
    {
        public ObjectCraftedCondition() => GeneratedLabel = "Object Crafted Condition";

        public ObjectCraftedConditionTypes CraftType { get; set; } = ObjectCraftedConditionTypes.WithTag;
        public ThresholdComparison QualityComparison { get; set; } = ThresholdComparison.GREATER_OR_EQUAL;
        public Reference QualityState { get; set; } = new Reference();
        public bool RestrictQuality { get; set; }
        public Reference Skill { get; set; } = new Reference();
        public ObservableCollection<string> Tags { get; set; } = new ObservableCollection<string>();

        protected override string GetVariantTunableName() => "crafted_item";

        protected override void OnExportVariant(TunableBase variantTunable)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>(GetVariantTunableName());

            if (RestrictQuality)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("quality_threshold", "enabled");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
                tunableTuple1.Set<TunableEnum>("comparison", "GREATER_OR_EQUAL");
                tunableTuple1.Set<TunableBasic>("value", QualityState);
            }

            if (CraftType == ObjectCraftedConditionTypes.UsingSkill)
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("skill_or_item", "crafted_with_skill");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("crafted_with_skill");
                tunableTuple1.Set<TunableBasic>("skill_to_test", Skill);
            }
            else
            {
                var tunableVariant1 = tupleTunable.Set<TunableVariant>("skill_or_item", "crafted_tagged_item");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("crafted_tagged_item");
                var tunableList1 = tunableTuple1.Get<TunableList>("tag_set");
                foreach (var tag in Tags)
                {
                    tunableList1.Set<TunableEnum>(null, tag);
                }
            }

            AutoTunerInvoker.Invoke(this, tupleTunable);
        }
    }
}