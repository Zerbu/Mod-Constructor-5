using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.ExportSystem.TuningActions;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Buffs.References;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;
using Constructor5.Xml;

namespace Constructor5.LootActionTypes.Buffs
{
    [SelectableObjectType("LootActionTypes", "Buffs: Add Buff (Persistant)", Description = "Adds a buff that will persist while the condition is met, and then be removed when it is no longer met. This is intended to be used with the \"Actions\" category on a trait or buff, and will not work properly if used anywhere else.")]
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
