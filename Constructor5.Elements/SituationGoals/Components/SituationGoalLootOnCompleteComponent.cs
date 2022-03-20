using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.LootActionSets;

namespace Constructor5.Elements.SituationGoals.Components
{
    [XmlSerializerExtraType]
    public class SituationGoalLootOnCompleteComponent : SituationGoalComponent
    {
        public ReferenceList ActionSets { get; set; } = new ReferenceList();
        public override string ComponentLabel => "ActionsOnComplete";

        protected internal override void OnExport(SituationGoalExportContext context)
        {
            if (!ActionSets.HasItems())
            {
                return;
            }

            var tunableList1 = context.Tuning.Get<TunableList>("_goal_loot_list");
            tunableList1.Set<TunableBasic>(null, CreateLimitedSupportLoot(context));
        }

        private ulong CreateLimitedSupportLoot(SituationGoalExportContext context)
        {
            var tuning = ElementTuning.Create(context.Element, "GoalLoot");
            tuning.Class = "SituationGoalLootActions";
            tuning.InstanceType = "action";
            tuning.Module = "situations.situation_goal";

            var tunableList1 = tuning.Get<TunableList>("goal_loot_actions");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "buff");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("buff");
            var tunableTuple2 = tunableTuple1.Get<TunableTuple>("buff");
            tunableTuple2.Set<TunableBasic>("buff_type", LootTriggerBuff.Create(context.Element, "GoalLootBuff", ElementTuning.GetInstanceKeys(ActionSets)));

            TuningExport.AddToQueue(tuning);

            return tuning.InstanceKey;
        }
    }
}