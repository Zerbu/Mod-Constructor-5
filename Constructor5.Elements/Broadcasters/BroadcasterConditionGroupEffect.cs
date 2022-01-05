using Constructor5.Core;

namespace Constructor5.Elements.Broadcasters
{
    [XmlSerializerExtraType]
    public class BroadcasterConditionGroupEffect : BroadcasterConditionGroupItem
    {
        public BroadcasterEffect Effect { get; set; } = new EmptyBroadcasterEffect();
    }
}