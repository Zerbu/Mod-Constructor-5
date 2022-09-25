using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.LootActionSets;
using Constructor5.Elements.TestConditions;

namespace Constructor5.LootActionTypes.ExtendedSupport
{
    public abstract class ExtendedSupportLootAction : LootAction
    {
        public string Participant { get; set; }

        protected override void OnExport(LASExportContext originalContext)
        {
            var mainTuple = LootTuning.GetActionTuple(originalContext.LootListTunable, "buff");

            var tunableTuple2 = mainTuple.Get<TunableTuple>("buff");
            tunableTuple2.Set<TunableBasic>("buff_type", LootTriggerBuff.Create(originalContext.Element, $"{ActionGuid}:Buff", new[] { CreateActionSet(originalContext) }));

            tunableTuple2.Set<TunableBasic>("subject", Participant);

            TestConditionTuning.TuneTestList(mainTuple, originalContext.TestConditions, "tests");
        }

        protected abstract void TuneLootContent(LASExportContext originalContext, TuningHeader tuning);

        private ulong CreateActionSet(LASExportContext originalContext)
        {
            var tuning = ElementTuning.Create(originalContext.Element, $"{ActionGuid}:Loot");
            tuning.Class = "LootActions";
            tuning.InstanceType = "action";
            tuning.Module = "interactions.utils.loot";

            var newContext = new LASExportContext(originalContext)
            {
                LootListTunable = tuning.Get<TunableList>("loot_actions")
            };
            TuneLootContent(newContext, tuning);

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}