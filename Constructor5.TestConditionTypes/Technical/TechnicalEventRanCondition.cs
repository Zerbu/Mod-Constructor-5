using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.TestConditions;
using System.Collections.ObjectModel;

namespace Constructor5.TestConditionTypes.Technical
{
    [SelectableObjectType("ObjectiveConditionTypes", "TechnicalEventsRanCondition", Description = "TechnicalEventsRanDescription")]
    [XmlSerializerExtraType]
    public class TechnicalEventRanCondition : TestCondition
    {
        public TechnicalEventRanCondition() => GeneratedLabel = "Technical Events Ran Condition";

        public ObservableCollection<string> Events { get; set; } = new ObservableCollection<string>();

        protected override string GetVariantTunableName(string contextTag = null) => "event_ran_successfully";

        protected override void OnExportVariant(TunableBase variantTunable, string contextTag)
        {
            var tupleTunable = variantTunable.Get<TunableTuple>("event_ran_successfully");
            var listTunable = tupleTunable.Get<TunableList>("test_events");
            foreach (var ev in Events)
            {
                listTunable.Set<TunableEnum>(null, ev);
            }
        }
    }
}