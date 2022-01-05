using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;

namespace Constructor5.Elements.LootActionSets
{
    [SelectableObjectType("LootActionTypes", "Do Nothing")]
    [XmlSerializerExtraType]
    public class EmptyLootAction : LootAction
    {
        public EmptyLootAction() => GeneratedLabel = "Do Nothing";

        protected internal override void OnExport(LASExportContext newContext)
        {
        }
    }
}
