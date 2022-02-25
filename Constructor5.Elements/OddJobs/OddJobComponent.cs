using Constructor5.Base.ComponentSystem;
using Constructor5.Elements.Traits;
using System.Xml.Serialization;

namespace Constructor5.Elements.OddJobs
{
    public abstract class OddJobComponent : ElementComponent, ITraitComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(OddJobExportContext context);
    }
}