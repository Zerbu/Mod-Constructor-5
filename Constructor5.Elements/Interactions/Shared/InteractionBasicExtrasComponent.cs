﻿using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using Constructor5.Elements.InteractionBasicExtras;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Super;
using Constructor5.Elements.TestConditions;
using Constructor5.UI.AutoGeneratedEditors;

namespace Constructor5.Elements.Interactions.Shared
{
    [XmlSerializerExtraType]
    [SocialInteractionComponent]
    [MixerInteractionComponent]
    [SuperInteractionComponent]
    public class InteractionBasicExtrasComponent : InteractionComponent
    {
        public override string ComponentLabel => "InteractionFeatures";

        public BasicExtrasList BasicExtras { get; set; } = new BasicExtrasList();

        protected internal override void OnExport(InteractionExportContext context)
        {
            BasicExtrasTuning.TuneBasicExtras(BasicExtras, context.Tuning.Get<TunableList>("basic_extras"));
        }
    }
}
