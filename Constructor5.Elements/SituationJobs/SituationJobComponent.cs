using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Situations;
using System.Xml.Serialization;

namespace Constructor5.Elements.SituationJobs
{
    public abstract class SituationJobComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(SituationJobExportContext context);
    }
}
