using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.Situations
{
    public abstract class SituationComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(SituationExportContext context);
    }
}