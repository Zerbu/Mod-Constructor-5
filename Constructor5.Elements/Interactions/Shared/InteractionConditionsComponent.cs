using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Constructor5.UI.AutoGeneratedEditors;
using Constructor5.Elements.Interactions.Super;

namespace Constructor5.Elements.Interactions.Shared
{
    [XmlSerializerExtraType]
    [SocialInteractionComponent]
    [MixerInteractionComponent]
    [SuperInteractionComponent]
    [HasAutoEditor("InteractionConditionsNotice")]
    public class InteractionConditionsComponent : InteractionComponent
    {
        public override string ComponentLabel => "Conditions";

        [AutoEditorConditionList]
        public TestConditionList Conditions { get; set; } = new TestConditionList();

        protected internal override void OnExport(InteractionExportContext context)
        {
            TestConditionTuning.TuneTestConditions(context.Tuning, Conditions.ToConditionList(), "test_globals");
        }
    }
}
