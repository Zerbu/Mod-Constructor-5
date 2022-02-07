using Constructor5.Base.ComponentSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.Careers
{
    public abstract class CareerComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(CareerExportContext context);
    }
}
