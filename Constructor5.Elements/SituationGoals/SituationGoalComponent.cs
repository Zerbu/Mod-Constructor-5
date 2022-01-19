using Constructor5.Base.ComponentSystem;
using System.Xml.Serialization;

namespace Constructor5.Elements.SituationGoals
{
    public abstract class SituationGoalComponent : ElementComponent, IComponentDisplayOrder
    {
        [XmlIgnore]
        public virtual int ComponentDisplayOrder { get; set; } = 10;

        protected internal abstract void OnExport(SituationGoalExportContext context);
    }
}