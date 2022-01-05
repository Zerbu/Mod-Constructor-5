using Constructor5.Base.ElementSystem;
using Constructor5.Xml;

namespace Constructor5.Elements.Buffs.Components
{
    [XmlSerializerExtraType]
    public class BuffLootItem : ReferenceListItem
    {
        public bool RunOnInterval { get; set; } = true;
        public bool RunOnAddition { get; set; }
        public bool RunOnInstance { get; set; }
        public bool RunOnRemoval { get; set; }
        public int IntervalMax { get; set; } = 10;
        public int IntervalMin { get; set; } = 10;
    }
}
