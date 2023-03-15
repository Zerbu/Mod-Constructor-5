using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Social;

namespace Constructor5.Elements.Interactions.Shared
{
    [SelectableObjectType("MixerInteractionTemplates", "Undefined")]
    [SelectableObjectType("SocialInteractionTemplates", "Undefined")]
    [SelectableObjectType("SuperInteractionTemplates", "Undefined")]
    [XmlSerializerExtraType]
    public class DefaultInteractionTemplate : InteractionTemplate
    {
        public override string Label => "Undefined";

        public override ulong GetCustomScoreTypeKey(InteractionExportContext context) => 0;

        public override ulong GetFallbackScoreType(SocialInteractionExportContext socialContext) => 0;

        protected internal override void OnExport(InteractionExportContext context)
        {
        }
    }
}
