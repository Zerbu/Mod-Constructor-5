using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.CompoundConditionElements;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using System.Collections.Generic;
using System.Linq;
using Constructor5.Base.ExportSystem;

namespace Constructor5.TestConditionTypes.Compound
{
    [SelectableObjectType("TestConditionTypes", "CompoundCondition")]
    [XmlSerializerExtraType]
    public class CompoundCondition : TestCondition
    {
        public CompoundCondition() => GeneratedLabel = "Compound Condition";

        public Reference CompoundConditionElement { get; set; } = new Reference();

        protected override string GetVariantTunableName(string contextTag = null) => "test_set_reference";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var instanceKey = ElementTuning.GetSingleInstanceKey(CompoundConditionElement);
            if (instanceKey == null)
            {
                Exporter.Current.AddError(null, "There was a reference to a Compound Condition Element that doesn't exist. It may have been deleted.");
                return;
            }
            variantTunable.Set<TunableBasic>("test_set_reference", instanceKey);
        }

        protected override void OnExportMain(TuningBase tuning, string tunableName = null, string contextTag = null)
        {
            var listTunable = (TunableList)tuning;

            var modReference = CompoundConditionElement?.Element as CompoundConditionElement;
            if (modReference == null || modReference.IsTuning)
            {
                base.OnExportMain(listTunable);
                return;
            }

            Exporter.Current.AddContextSpecificElement(CompoundConditionElement.Element);
            var orGroup = modReference.OrGroups.FirstOrDefault();
            if (orGroup == null)
            {
                return;
            }

            var conditions = new List<TestCondition>();
            foreach(var andCondition in orGroup.AndConditions)
            {
                conditions.Add(andCondition.Condition);
            }

            TestConditionTuning.TuneTestConditions(listTunable, conditions, null, contextTag);
        }
    }
}
