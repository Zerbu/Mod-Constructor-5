using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Situations
{
    [XmlSerializerExtraType]
    public class StartSituationInvitedParticipant
    {
        public string Participant { get; set; }
        public Reference SituationJob { get; set; } = new Reference();
    }
}
