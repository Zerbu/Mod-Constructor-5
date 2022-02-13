using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.SituationTemplates.SimpleSituation
{
    [XmlSerializerExtraType]
    public class RoleStateChange
    {
        public int DurationToEndAt { get; set; } = 60;
        public Reference RoleStateToChangeTo { get; set; } = new Reference(99710, "Generic");
    }
}
