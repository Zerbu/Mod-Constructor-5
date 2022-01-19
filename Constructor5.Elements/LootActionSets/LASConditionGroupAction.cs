using Constructor5.Core;
using System;

namespace Constructor5.Elements.LootActionSets
{
    [XmlSerializerExtraType]
    public class LASConditionGroupAction : LASConditionGroupItem
    {
        public LootAction Action { get; set; } = new EmptyLootAction();
    }
}
