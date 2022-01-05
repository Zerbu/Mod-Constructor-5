using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.TestConditions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.CompoundConditionElements
{
    [ElementTypeData("Compound Condition Element", true, ElementTypes = new[] { typeof(CompoundConditionElement) }, PresetFolders = new[] { "TestSetReference" })]
    public class CompoundConditionElement : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();
        public bool IsTuning => OrGroups.Count > 1 || !string.IsNullOrEmpty(CustomTuning.Text);
        public ObservableCollection<CompoundConditionOrGroup> OrGroups { get; } = new ObservableCollection<CompoundConditionOrGroup>();

        void IExportableElement.OnExport()
        {
            if (!IsTuning)
            {
                return;
            }

            var tuning = ElementTuning.Create(this);
            tuning.Class = "TestSetInstance";
            tuning.InstanceType = "snippet";
            tuning.Module = "event_testing.tests";

            foreach (var group in OrGroups)
            {
                var conditions = new List<TestCondition>();

                foreach (var andCondition in group.AndConditions)
                {
                    conditions.Add(andCondition.Condition);
                }

                TestConditionTuning.TuneTestList(tuning, conditions, "test");
            }

            CustomTuningExporter.Export(tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}