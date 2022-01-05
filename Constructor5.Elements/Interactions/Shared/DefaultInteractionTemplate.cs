using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Shared
{
    [XmlSerializerExtraType]
    public class DefaultInteractionTemplate : InteractionTemplate
    {
        public override string Label => "Undefined";

        protected internal override void OnExport(InteractionExportContext context)
        {
        }
    }
}
