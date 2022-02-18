using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.Traits
{
    public abstract class TraitComponent : ElementComponent, ITraitComponent
    {
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(TraitExportContext context);
    }
}
