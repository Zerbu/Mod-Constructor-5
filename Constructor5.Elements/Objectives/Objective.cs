using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Objectives
{
    [ElementTypeData("Objective", false, ElementTypes = new[] { typeof(Objective) }, PresetFolders = new[] { "Objective" })]
    public class Objective : Element, IExportableElement, ISupportsCustomTuning
    {
        [AutoTuneIfFalse("relative_to_unlock_moment", "True")]
        public bool AlwaysTrack { get; set; } = true;

        public ObjectiveCompletionType CompletionType { get; set; } = ObjectiveCompletionType.BasedOnObjectiveType;
        public int CompletionTypeValue { get; set; } = 1;
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public bool HomeLotOnly { get; set; }

        [AutoTuneBasic("display_text")]
        public STBLString Name { get; set; } = new STBLString();

        public ObservableCollection<TestConditionListItem> PostConditions { get; set; } = new ObservableCollection<TestConditionListItem>();

        public TestCondition PrimaryCondition { get; set; } = new AlwaysRunCondition();

        [AutoTuneBasic("satisfaction_points")]
        public int SatisfactionPoints { get; set; }

        [AutoTuneBasic("tooltip")]
        public STBLString ToolTip { get; set; } = new STBLString();

        // public bool IsResettable { get; set; }

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Objective";
            tuning.InstanceType = "objective";
            tuning.Module = "event_testing.objective_tuning";

            tuning.SimDataHandler = new SimDataHandler($"SimData/Objective.data");

            //tuning.SimDataHandler = new SimDataHandler("SimData/Trait.data");

            TuneCompletionType(tuning);

            TestConditionTuning.TuneSingleTestCondition(tuning, PrimaryCondition, "objective_test");

            var postConditions = new List<TestCondition>();
            foreach (var condition in PostConditions)
            {
                postConditions.Add(condition.Condition);
            }

            TestConditionTuning.TuneTestConditions(tuning, postConditions, "additional_tests");

            AutoTunerInvoker.Invoke(this, tuning);

            BuildSimData(tuning);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void BuildSimData(TuningHeader tuning)
        {
            tuning.SimDataHandler.WriteText(64, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            tuning.SimDataHandler.Write(68, SatisfactionPoints);
            tuning.SimDataHandler.WriteText(72, Exporter.Current.STBLBuilder.GetKey(ToolTip) ?? 0);
        }

        private void TuneCompletionType(TuningHeader tuning)
        {
            switch (CompletionType)
            {
                case ObjectiveCompletionType.BasedOnObjectiveType:
                    {
                        var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "use_test_result");
                        if (HomeLotOnly)
                        {
                            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("use_test_result");
                            tunableTuple1.Set<TunableBasic>("only_use_result_on_home_zone", "True");
                        }
                        break;
                    }
                case ObjectiveCompletionType.Iterations:
                    {
                        var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "iterations");
                        var tunableTuple1 = tunableVariant1.Get<TunableTuple>("iterations");
                        tunableTuple1.Set<TunableBasic>("iterations_required_to_pass", CompletionTypeValue);
                        break;
                    }
                case ObjectiveCompletionType.IterationsInSingleSituation:
                    {
                        var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "iterations_single_situation");
                        var tunableTuple1 = tunableVariant1.Get<TunableTuple>("iterations_single_situation");
                        tunableTuple1.Set<TunableBasic>("iterations_required_to_pass", CompletionTypeValue);
                        break;
                    }
                case ObjectiveCompletionType.UniqueAreas:
                    {
                        var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "unique_worlds");
                        var tunableTuple1 = tunableVariant1.Get<TunableTuple>("unique_worlds");
                        tunableTuple1.Set<TunableBasic>("unique_worlds_required_to_pass", CompletionTypeValue);
                        break;
                    }
                case ObjectiveCompletionType.UniqueLots:
                    {
                        var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "unique_locations");
                        var tunableTuple1 = tunableVariant1.Get<TunableTuple>("unique_locations");
                        tunableTuple1.Set<TunableBasic>("unique_locations_required_to_pass", CompletionTypeValue);
                        break;
                    }
                case ObjectiveCompletionType.UniqueTargets:
                    {
                        var tunableVariant1 = tuning.Set<TunableVariant>("objective_completion_type", "unique_targets");
                        var tunableTuple1 = tunableVariant1.Get<TunableTuple>("unique_targets");
                        tunableTuple1.Set<TunableBasic>("unique_targets_required_to_pass", CompletionTypeValue);
                        break;
                    }
            }
        }
    }
}