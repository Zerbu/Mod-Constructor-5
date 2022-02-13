using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.SelectableObjects;
using Constructor5.Elements.Situations;
using Constructor5.Core;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.SituationTemplates.SimpleSituation
{
    [SelectableObjectType("SituationTemplates", "SimpleSituation")]
    [XmlSerializerExtraType]
    public class SimpleSituationTemplate : SituationTemplate
    {
        public ReferenceList Jobs { get; set; } = new ReferenceList();
        public override string Label => "Simple Situation";

        protected override void OnExport(SituationExportContext context)
        {
            var phaseList = context.Tuning.Get<TunableList>("_phases");

            var roleChangeEndPoints = new HashSet<int>();

            var currentStates = new Dictionary<SimpleSituationJobItem, ulong>();

            foreach (var job in Jobs.GetOfType<SimpleSituationJobItem>())
            {
                var firstState = job.RoleStateChanges.OrderByDescending(x=>x.DurationToEndAt).FirstOrDefault()?.RoleStateToChangeTo;
                if (firstState == null)
                {
                    firstState = job.RoleState;
                }

                currentStates.Add(job, (ulong)ElementTuning.GetSingleInstanceKey(firstState));

                foreach(var stateChange in job.RoleStateChanges)
                {
                    roleChangeEndPoints.Add(stateChange.DurationToEndAt);
                }
            }

            foreach (var endPoint in roleChangeEndPoints.OrderByDescending(x=>x))
            {
                var tuple = phaseList.Get<TunableTuple>(null);
                tuple.Set<TunableBasic>("duration", endPoint);
                var tunableList1 = tuple.Get<TunableList>("job_list");

                foreach (var job in Jobs.GetOfType<SimpleSituationJobItem>())
                {
                    var newCurrentState = job.RoleStateChanges.FirstOrDefault(x=>x.DurationToEndAt==endPoint);
                    if (newCurrentState != null)
                    {
                        currentStates[job] = (ulong)ElementTuning.GetSingleInstanceKey(newCurrentState.RoleStateToChangeTo);
                    }

                    foreach (var key in ElementTuning.GetInstanceKeys(job.Reference))
                    {
                        var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                        tunableTuple1.Set<TunableBasic>("job", key);
                        tunableTuple1.Set<TunableBasic>("role", currentStates[job]);
                    }
                }
            }

            var zeroTuple = phaseList.Get<TunableTuple>(null);
            zeroTuple.Set<TunableBasic>("duration", 0);

            foreach (var job in Jobs.GetOfType<SimpleSituationJobItem>())
            {
                foreach(var key in ElementTuning.GetInstanceKeys(job.Reference))
                {
                    {
                        var tunableList1 = zeroTuple.Get<TunableList>("job_list");
                        var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                        tunableTuple1.Set<TunableBasic>("job", key);
                        tunableTuple1.Set<TunableBasic>("role", job.RoleState);
                    }
                    {
                        var tunableVariant1 = context.Tuning.Set<TunableVariant>("job_display_ordering", "enabled");
                        var tunableList1 = tunableVariant1.Get<TunableList>("enabled");
                        tunableList1.Set<TunableBasic>(null, key);
                    }
                }

            }
        }
    }
}