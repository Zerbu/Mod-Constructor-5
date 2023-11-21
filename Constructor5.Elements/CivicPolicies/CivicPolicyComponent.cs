using Constructor5.Base.ComponentSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.CivicPolicies
{
    public abstract class CivicPolicyComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder => 10;

        protected internal abstract void OnExport(CivicPolicyExportContext context);
    }
}