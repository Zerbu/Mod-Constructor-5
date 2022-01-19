using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.LootActionSets
{
    [ElementTypeData("LootActionSet", true,
        ElementTypes = new[] { typeof(LootActionSet) },
        PresetFolders = new[] { "Loot" })]
    public class LootActionSet : Element, IExportableElement, ISupportsCustomTuning
    {
        public ObservableCollection<LASConditionGroup> ConditionGroups { get; } = new ObservableCollection<LASConditionGroup>();
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "LootActions";
            tuning.InstanceType = "action";
            tuning.Module = "interactions.utils.loot";

            var context = new LASExportContext()
            {
                LootListTunable = tuning.Get<TunableList>("loot_actions")
            };

            foreach (var group in ConditionGroups)
            {
                ExportConditionGroup(group, context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void ExportConditionGroup(LASConditionGroup group, LASExportContext originalContext)
        {
            var newContext = new LASExportContext(originalContext)
            {
                Element = this
            };

            newContext.TestConditions.Add(group.Condition);

            foreach (var item in group.Items)
            {
                if (item is LASConditionGroup nestedGroup)
                {
                    ExportConditionGroup(nestedGroup, newContext);
                }

                if (item is LASConditionGroupAction action)
                {
                    action.Action.OnExport(newContext);
                    // export action
                }
            }
        }
    }
}