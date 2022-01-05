using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Traits;
using System.Xml.Serialization;

namespace Constructor5.Elements.Buffs
{
    public abstract class BuffComponent : ElementComponent, ITraitComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract bool HasContent();

        protected internal abstract void OnExport(BuffExportContext context);
    }
}