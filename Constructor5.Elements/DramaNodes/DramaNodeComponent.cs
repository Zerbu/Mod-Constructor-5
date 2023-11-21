using Constructor5.Base.ComponentSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.DramaNodes
{
    public abstract class DramaNodeComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(DramaNodeExportContext context);
    }
}
