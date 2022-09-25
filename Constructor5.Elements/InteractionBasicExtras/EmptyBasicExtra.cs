using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.InteractionBasicExtras
{
    [SelectableObjectType("BasicExtraTypes", "DoNothing")]
    [XmlSerializerExtraType]
    public class EmptyBasicExtra : BasicExtra
    {
        public EmptyBasicExtra() => GeneratedLabel = "Do Nothing";

        protected internal override void OnExport(BasicExtraExportContext originalContext)
        {
            return;
        }
    }
}
