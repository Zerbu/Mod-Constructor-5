using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.Situations.Components
{
    [SelectableObjectType("SituationTemplates", "DefaultSituationTemplate")]
    [XmlSerializerExtraType]
    public class DefaultSituationTemplate : SituationTemplate
    {
        public override string Label => "No Situation Type Selected";

        protected internal override void OnExport(SituationExportContext context)
        {
        }
    }
}