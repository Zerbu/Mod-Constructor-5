using Constructor5.Base.ComponentSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.HolidayTraditions
{
    public abstract class HolidayTraditionComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(HolidayTraditionExportContext context);
    }
}