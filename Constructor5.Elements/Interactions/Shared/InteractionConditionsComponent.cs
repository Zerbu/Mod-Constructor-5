using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Interactions.Shared
{
    [XmlSerializerExtraType]
    [SocialInteractionComponent]
    [MixerInteractionComponent]
    public class InteractionConditionsComponent : InteractionComponent
    {
        public override string ComponentLabel => "Conditions";

        public ObservableCollection<TestConditionListItem> Conditions { get; set; } = new ObservableCollection<TestConditionListItem>();

        protected internal override void OnExport(InteractionExportContext context)
        {
            var conditions = new List<TestCondition>();
            foreach(var condition in Conditions)
            {
                conditions.Add(condition.Condition);
            }

            TestConditionTuning.TuneTestConditions(context.Tuning, conditions, "test_globals");
        }
    }
}
