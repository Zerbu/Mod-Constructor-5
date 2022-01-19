using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.Elements.SimFilters
{
    [SelectableObjectType("SimFilterTypes", "Always Pass")]
    [XmlSerializerExtraType]
    public class DefaultSimFilterTerm : SimFilterTerm
    {
        public DefaultSimFilterTerm() => GeneratedLabel = "Always Pass";

        protected internal override void OnExport(TunableList filterTermsTunable)
        {
        }
    }
}