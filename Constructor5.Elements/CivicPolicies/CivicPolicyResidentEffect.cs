using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.CivicPolicies
{
    [XmlSerializerExtraType]
    public class CivicPolicyResidentEffect : CivicPolicyComponent
    {
        public override string ComponentLabel => "CivicPolicyResidentEffect";

        [AutoTuneReferenceList("enact_loot")]
        public ReferenceList ResidentLootEnact { get; set; } = new ReferenceList();

        [AutoTuneReferenceList("repeat_loot")]
        public ReferenceList ResidentLootRepeal { get; set; } = new ReferenceList();

        protected internal override void OnExport(CivicPolicyExportContext context)
        {
            var tuning = ElementTuning.Create(context.Element, "ResidentEffect");
            tuning.Class = "StreetResidentSimLootEffect";
            tuning.InstanceType = "snippet";
            tuning.Module = "civic_policies.street_civic_policy_effect";

            AutoTunerInvoker.Invoke(this, tuning);

            /*if (ElementTuning.GetSingleInstanceKey(AutoBuff) != 0)
            {
                TuneAutoBuff(context, tuning);
            }*/

            TuningExport.AddToQueue(tuning);

            context.Tuning.Get<TunableList>("civic_policy_effects").Set<TunableBasic>(null, tuning.InstanceKey);
        }

        /*private void TuneAutoBuff(CivicPolicyExportContext context, TuningHeader effectTuning)
        {
            // Add
            {
                var tuning = ElementTuning.Create(context.Element, "ResidentEffectAutoEnact");
                tuning.Class = "LootActions";
                tuning.InstanceType = "action";
                tuning.Module = "interactions.utils.loot";

                var tunableList1 = tuning.Get<TunableList>("loot_actions");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "buff");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("buff");
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("buff");
                tunableTuple2.Set<TunableBasic>("buff_type", ElementTuning.GetSingleInstanceKey(AutoBuff));

                effectTuning.Get<TunableList>("enact_loot").Set<TunableBasic>(null, tuning.InstanceKey);

                TuningExport.AddToQueue(tuning);
            }

            // Remove
            {
                var tuning = ElementTuning.Create(context.Element, "ResidentEffectAutoRepeal");
                tuning.Class = "LootActions";
                tuning.InstanceType = "action";
                tuning.Module = "interactions.utils.loot";

                var tunableList1 = tuning.Get<TunableList>("loot_actions");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "buff_removal");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("buff_removal");
                var tunableList2 = tunableTuple1.Get<TunableList>("buffs_to_remove");
                tunableList2.Set<TunableBasic>(null, ElementTuning.GetSingleInstanceKey(AutoBuff));

                effectTuning.Get<TunableList>("repeal_loot").Set<TunableBasic>(null, tuning.InstanceKey);

                TuningExport.AddToQueue(tuning);
            }
        }*/
    }
}
