using Constructor5.Xml;

namespace Constructor5.Elements.Broadcasters
{
    [XmlSerializerExtraType]
    public class BroadcasterConditionGroupEffect : BroadcasterConditionGroupItem
    {
        public BroadcasterEffect Effect { get; set; } = new EmptyBroadcasterEffect();
    }
}