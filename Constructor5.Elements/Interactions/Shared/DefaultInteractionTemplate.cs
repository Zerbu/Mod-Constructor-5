using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Shared
{
    [SelectableObjectType("MixerInteractionTemplates", "Undefined")]
    [SelectableObjectType("SocialInteractionTemplates", "Undefined")]
    [SelectableObjectType("SuperInteractionTemplates", "Undefined")]
    [XmlSerializerExtraType]
    public class DefaultInteractionTemplate : InteractionTemplate
    {
        public override string Label => "Undefined";

        protected internal override void OnExport(InteractionExportContext context)
        {
        }
    }
}
