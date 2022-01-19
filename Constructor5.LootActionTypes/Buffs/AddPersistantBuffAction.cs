using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Core;

namespace Constructor5.LootActionTypes.Buffs
{
    [SelectableObjectType("LootActionTypes", "BuffsAddBuffPersistant", Description = "BuffsAddBuffPersistantNotice")]
    [XmlSerializerExtraType]
    public class AddPersistantBuffAction : LootAction
    {
        public AddPersistantBuffAction() => GeneratedLabel = "Add Buff (Persistant)";

        public BuffWithReason Buff { get; set; } = new BuffWithReason();

        protected override void OnExport(LASExportContext originalContext)
        {
            var tunableVariant1 = originalContext.LootListTunable.Set<TunableVariant>(null, "statistics");
            var mainTuple = tunableVariant1.GetVariant<TunableTuple>("statistics", "statistic_set_max");

            AutoTunerInvoker.Invoke(this, originalContext.LootListTunable);

            mainTuple.Set<TunableBasic>("stat", CreateCommodity(originalContext));

            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");
        }

        private ulong CreateCommodity(LASExportContext originalContext)
        {
            var tuning = ElementTuning.Create(originalContext.Element, $"{ActionGuid}:Commodity");
            tuning.Class = "Commodity";
            tuning.InstanceType = "statistic";
            tuning.Module = "statistics.commodity";

            TuningActionInvoker.InvokeFromFile("Persistant Buff Commodity", new TuningActionContext
            {
                Tuning = tuning,
                DataContext = this,
            });

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}
