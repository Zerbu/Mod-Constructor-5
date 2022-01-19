using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System.Collections.ObjectModel;

namespace Constructor5.Elements.Broadcasters
{
    [ElementTypeData("Broadcaster", true, ElementTypes = new[] { typeof(Broadcaster) }, PresetFolders = new[] { "Broadcaster" })]
    public class Broadcaster : Element, IExportableElement, ISupportsCustomTuning
    {
        public ObservableCollection<BroadcasterConditionGroup> ConditionGroups { get; } = new ObservableCollection<BroadcasterConditionGroup>();
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        /*public int Constraint { get; set; } = 6;
        public int PulseFrequency { get; set; } = 6;*/

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Broadcaster";
            tuning.InstanceType = "broadcaster";
            tuning.Module = "broadcasters.broadcaster";

            var tunableList1 = tuning.Get<TunableList>("constraints");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "line_of_sight");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("line_of_sight");
            var tunableVariant2 = tunableTuple1.Set<TunableVariant>("temporary_los", "enabled");

            /*var tunableList1 = tuning.Get<TunableList>("constraints");
            var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "circle");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("circle");
            tunableTuple1.Set<TunableBasic>("radius", Constraint);
            var tunableVariant2 = tuning.Set<TunableVariant>("frequency", "on_pulse");
            var tunableTuple2 = tunableVariant2.Get<TunableTuple>("on_pulse");
            tunableTuple2.Set<TunableBasic>("cooldown_time", PulseFrequency);*/

            var context = new BroadcasterExportContext()
            {
                EffectListTunable = tuning.Get<TunableList>("effects")
            };

            foreach (var group in ConditionGroups)
            {
                ExportConditionGroup(group, context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        private void ExportConditionGroup(BroadcasterConditionGroup group, BroadcasterExportContext originalContext)
        {
            var newContext = new BroadcasterExportContext(originalContext);
            newContext.TestConditions.Add(group.Condition);

            foreach (var item in group.Items)
            {
                if (item is BroadcasterConditionGroup nestedGroup)
                {
                    ExportConditionGroup(nestedGroup, newContext);
                }

                if (item is BroadcasterConditionGroupEffect effect)
                {
                    effect.Effect.OnExport(newContext);
                }
            }
        }
    }
}