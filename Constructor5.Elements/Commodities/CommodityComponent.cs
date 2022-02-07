using Constructor5.Base.ComponentSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.Commodities
{
    public abstract class CommodityComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(CommodityExportContext context);
    }
}
