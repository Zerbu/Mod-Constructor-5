using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.OddJobs.Components
{
    [XmlSerializerExtraType]
    public class OddJobActionsComponent : OddJobComponent
    {
        public override string ComponentLabel => "ActionsOnComplete";

        public ReferenceList ActionSets { get; set; } = new ReferenceList();

        protected internal override void OnExport(OddJobExportContext context)
        {
            var greatSuccessKeys = new List<ulong>();
            var normalSuccessKeys = new List<ulong>();
            var normalFailureKeys = new List<ulong>();
            var criticalFailureKeys = new List<ulong>();

            foreach (var set in ActionSets.GetOfType<OddJobActionsItem>())
            {
                foreach (var key in ElementTuning.GetInstanceKeys(set.Reference))
                {
                    if (set.RunOnGreatSuccess)
                    {
                        greatSuccessKeys.Add(key);
                    }
                    if (set.RunOnNormalSuccess)
                    {
                        normalSuccessKeys.Add(key);
                    }
                    if (set.RunOnNormalFailure)
                    {
                        normalFailureKeys.Add(key);
                    }
                    if (set.RunOnCriticalFailure)
                    {
                        criticalFailureKeys.Add(key);
                    }
                }
            }

            var assignmentsComponent = context.Element.GetComponent<OddJobAssignmentsComponent>();

            var tunableVariant1 = context.Tuning.Set<TunableVariant>("result_based_loots", "enabled");
            var tunableList1 = tunableVariant1.Get<TunableList>("enabled");
            var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
            tunableTuple1.Set<TunableEnum>("key", "CRITICAL_FAILURE");
            var tunableList2 = tunableTuple1.Get<TunableList>("value");

            if (assignmentsComponent.IsAssignmentJob)
            {
                tunableList2.Set<TunableBasic>(null, "212878");
                tunableList2.Set<TunableBasic>(null, "278795");
            }
            else
            {
                tunableList2.Set<TunableBasic>(null, "211558");
                tunableList2.Set<TunableBasic>(null, "278795");
            }

            foreach (var key in criticalFailureKeys)
            {
                tunableList2.Set<TunableBasic>(null, key);
            }

            if (normalFailureKeys.Count > 0)
            {
                var tuple = tunableList1.Get<TunableTuple>(null);
                tuple.Set<TunableEnum>("key", "FAILURE");
                var value = tuple.Get<TunableList>("value");
                foreach (var key in normalFailureKeys)
                {
                    value.Set<TunableBasic>(null, key);
                }
            }

            var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
            tunableTuple2.Set<TunableEnum>("key", "GREAT_SUCCESS");
            var tunableList3 = tunableTuple2.Get<TunableList>("value");

            if (assignmentsComponent.IsAssignmentJob)
            {
                tunableList3.Set<TunableBasic>(null, "212880");
                tunableList3.Set<TunableBasic>(null, "278795");
            }
            else
            {
                tunableList3.Set<TunableBasic>(null, "211560");
                tunableList3.Set<TunableBasic>(null, "278795");
            }

            foreach (var key in greatSuccessKeys)
            {
                tunableList3.Set<TunableBasic>(null, key);
            }

            if (normalSuccessKeys.Count > 0)
            {
                var tuple = tunableList1.Get<TunableTuple>(null);
                tuple.Set<TunableEnum>("key", "SUCCESS");
                var value = tuple.Get<TunableList>("value");
                foreach (var key in normalSuccessKeys)
                {
                    value.Set<TunableBasic>(null, key);
                }
            }
        }
    }
}
