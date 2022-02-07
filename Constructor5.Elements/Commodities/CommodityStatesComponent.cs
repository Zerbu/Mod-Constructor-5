using Constructor5.Core;
using Constructor5.Elements.Commodities.Generators;

namespace Constructor5.Elements.Commodities
{
    [XmlSerializerExtraType]
    public class CommodityStatesComponent : CommodityComponent
    {
        //public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "States";

        public CommodityStateGenerator Generator { get; set; } = new BuffBasedStateGenerator();

        protected internal override void OnExport(CommodityExportContext context) => Generator.OnExport(context);
    }
}