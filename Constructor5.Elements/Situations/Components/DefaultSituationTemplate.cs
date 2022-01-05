using Constructor5.Core;

namespace Constructor5.Elements.Situations.Components
{
    [XmlSerializerExtraType]
    public class DefaultSituationTemplate : SituationTemplate
    {
        public override string Label => "Undefined";

        protected internal override void OnExport(SituationExportContext context)
        {
        }
    }
}