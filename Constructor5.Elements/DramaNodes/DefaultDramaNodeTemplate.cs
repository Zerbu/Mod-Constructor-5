using Constructor5.Core;

namespace Constructor5.Elements.DramaNodes
{
    [XmlSerializerExtraType]
    public class DefaultDramaNodeTemplate : DramaNodeTemplate
    {
        public override string Label => "No Drama Node Type Selected";

        protected internal override void OnExport(DramaNodeExportContext context)
        {
        }
    }
}
