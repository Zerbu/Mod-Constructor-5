using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.ZoneDirectors
{
    [SelectableObjectType("ZoneDirectorTemplates", "DefaultZoneDirectorTemplate")]
    [XmlSerializerExtraType]
    public class DefaultZoneDirectorTemplate : ZoneDirectorTemplate
    {
        public override string Label => "No Zone Director Type Selected";

        protected internal override void OnExport(ZoneDirectorExportContext context)
        {
        }
    }
}