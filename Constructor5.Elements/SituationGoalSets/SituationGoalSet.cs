using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.SituationGoals;
using System.Collections.Generic;

namespace Constructor5.Elements.SituationGoalSets
{
    [ElementTypeData("SituationGoalSet", false, ElementTypes = new[] { typeof(SituationGoalSet) }, PresetFolders = new[] { "SituationGoalSet" })]
    public class SituationGoalSet : Element, IExportableElement, ISupportsCustomTuning
    {
        public bool AddSelfAsChainedGoalSet { get; set; }
        public ReferenceList ChainedGoalSets { get; set; } = new ReferenceList();
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public ReferenceList Goals { get; set; } = new ReferenceList();
        public bool LinearModeEnabled { get; set; }

        void IExportableElement.OnExport()
        {
            var mainTuning = CreateTuning(null);

            var goals = Goals.GetOfType<WeightedGoalReferenceListItem>();
            var currentTuning = mainTuning;
            for (int i = 0; i < goals.Length; i++)
            {
                var goal = goals[i];

                var tunableList1 = currentTuning.Get<TunableList>("goals");
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableBasic>("goal", goal.Reference);
                if (goal.Weight != 1)
                {
                    tunableTuple1.Set<TunableBasic>("weight", goal.Weight);
                }

                if (LinearModeEnabled && i < goals.Length - 1)
                {
                    var newTuning = CreateTuning($"Chained{i + 1}");
                    var chainedList = currentTuning.Get<TunableList>("chained_goal_sets");
                    chainedList.Set<TunableBasic>(null, newTuning.InstanceKey);
                    currentTuning = newTuning;
                }
            }

            if (AddSelfAsChainedGoalSet || ChainedGoalSets.HasItems())
            {
                var tunableList1 = currentTuning.Get<TunableList>("chained_goal_sets");
                if (AddSelfAsChainedGoalSet)
                {
                    tunableList1.Set<TunableBasic>(null, new Reference(this));
                }
                foreach (var chainedGoalSet in ElementTuning.GetInstanceKeys(ChainedGoalSets))
                {
                    tunableList1.Set<TunableBasic>(null, chainedGoalSet);
                }
            }

            foreach (var tuning in AllTuning)
            {
                TuningExport.AddToQueue(tuning);
            }

            AllTuning.Clear();
        }

        private List<TuningHeader> AllTuning { get; } = new List<TuningHeader>();

        private TuningHeader CreateTuning(string suffix)
        {
            var result = ElementTuning.Create(this, suffix);
            result.Class = "SituationGoalSet";
            result.InstanceType = "situation_goal_set";
            result.Module = "situations.situation_goal_set";
            AllTuning.Add(result);
            return result;
        }
    }
}