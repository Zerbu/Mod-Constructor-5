using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.LootActionSets;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Statistic
{
    [SelectableObjectType("LootActionTypes", "Statistics: Add Statistic")]
    [XmlSerializerExtraType]
    public class AddStatisticAction : StatisticActionBase
    {
        public AddStatisticAction() => GeneratedLabel = "Add Statistic";

        protected override void OnExport(LASExportContext newContext)
        {
        }
    }
}
