using Constructor5.Xml;
using System;

namespace Constructor5.Elements.LootActionSets
{
    [XmlSerializerExtraType]
    public class LASConditionGroupAction : LASConditionGroupItem
    {
        public LootAction Action { get; set; } = new EmptyLootAction();
    }
}
