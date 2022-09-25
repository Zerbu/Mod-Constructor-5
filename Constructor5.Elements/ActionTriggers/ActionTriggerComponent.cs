using Constructor5.Base.ComponentSystem;
using Constructor5.Elements.SituationGoals;
using System.Xml.Serialization;

namespace Constructor5.Elements.ActionTriggers
{
    public abstract class ActionTriggerComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder { get; set; } = 10;

        protected internal abstract void OnExport(ActionTriggerExportContext context);
    }
}
