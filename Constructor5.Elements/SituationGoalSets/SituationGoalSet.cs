using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.SituationGoals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.SituationGoalSets
{
    [ElementTypeData("Situation Goal Set", false, ElementTypes = new[] { typeof(SituationGoalSet) }, PresetFolders = new[] { "SituationGoalSet" })]
    public class SituationGoalSet : Element, IExportableElement
    {
        public bool AddSelfAsChainedGoalSet { get; set; } = true;

        [AutoTuneReferenceList("chained_goal_sets")]
        public ReferenceList ChainedGoalSets { get; set; } = new ReferenceList();

        public ReferenceList Goals { get; set; } = new ReferenceList();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SituationGoalSet";
            tuning.InstanceType = "situation_goal_set";
            tuning.Module = "situations.situation_goal_set";

            if (AddSelfAsChainedGoalSet)
            {
                var tunableList1 = tuning.Get<TunableList>("chained_goal_sets");
                tunableList1.Set<TunableBasic>(null, new Reference(this));
            }

            AutoTunerInvoker.Invoke(this, tuning);

            foreach(var goal in Goals.GetOfType<WeightedGoalReferenceListItem>())
            {
                var tunableList1 = tuning.Get<TunableList>("goals");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("goal", goal.Reference);
                if (goal.Weight != 1)
                {
                    tunableTuple1.Set<TunableBasic>("weight", goal.Weight);
                }
            }

            TuningExport.AddToQueue(tuning);
        }
    }
}
