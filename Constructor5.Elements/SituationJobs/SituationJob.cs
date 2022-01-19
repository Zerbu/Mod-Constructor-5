using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.SituationJobs.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.SituationJobs
{
    [ElementTypeData("SituationJob", false, ElementTypes = new[] { typeof(SituationJob) }, PresetFolders = new[] { "SituationJob" })]
    public class SituationJob : SimpleComponentElement<SituationJobComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SituationJob";
            tuning.InstanceType = "situation_job";
            tuning.Module = "situations.situation_job";

            {
                var tunableList1 = tuning.Get<TunableList>("commodities");
                var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "statistic_set_in_range");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("statistic_set_in_range");
                tunableTuple1.Set<TunableBasic>("stat", "16652");
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("value_type", "int_range");
                var tunableTuple2 = tunableVariant2.Get<TunableTuple>("int_range");
                var tunableTuple3 = tunableTuple2.Get<TunableTuple>("value_range");
                tunableTuple3.Set<TunableBasic>("lower_bound", "75");
                tunableTuple3.Set<TunableBasic>("upper_bound", "100");
                var tunableVariant3 = tunableList1.Set<TunableVariant>(null, "statistic_set_in_range");
                var tunableTuple4 = tunableVariant3.Get<TunableTuple>("statistic_set_in_range");
                tunableTuple4.Set<TunableBasic>("stat", "16654");
                var tunableVariant4 = tunableTuple4.Set<TunableVariant>("value_type", "int_range");
                var tunableTuple5 = tunableVariant4.Get<TunableTuple>("int_range");
                var tunableTuple6 = tunableTuple5.Get<TunableTuple>("value_range");
                tunableTuple6.Set<TunableBasic>("lower_bound", "75");
                tunableTuple6.Set<TunableBasic>("upper_bound", "100");
                var tunableVariant5 = tunableList1.Set<TunableVariant>(null, "statistic_set_in_range");
                var tunableTuple7 = tunableVariant5.Get<TunableTuple>("statistic_set_in_range");
                tunableTuple7.Set<TunableBasic>("stat", "16655");
                var tunableVariant6 = tunableTuple7.Set<TunableVariant>("value_type", "int_range");
                var tunableTuple8 = tunableVariant6.Get<TunableTuple>("int_range");
                var tunableTuple9 = tunableTuple8.Get<TunableTuple>("value_range");
                tunableTuple9.Set<TunableBasic>("lower_bound", "75");
                tunableTuple9.Set<TunableBasic>("upper_bound", "100");
                var tunableVariant7 = tunableList1.Set<TunableVariant>(null, "statistic_set_in_range");
                var tunableTuple10 = tunableVariant7.Get<TunableTuple>("statistic_set_in_range");
                tunableTuple10.Set<TunableBasic>("stat", "16656");
                var tunableVariant8 = tunableTuple10.Set<TunableVariant>("value_type", "int_range");
                var tunableTuple11 = tunableVariant8.Get<TunableTuple>("int_range");
                var tunableTuple12 = tunableTuple11.Get<TunableTuple>("value_range");
                tunableTuple12.Set<TunableBasic>("lower_bound", "-20");
                tunableTuple12.Set<TunableBasic>("upper_bound", "0");
                var tunableVariant9 = tunableList1.Set<TunableVariant>(null, "statistic_set_in_range");
                var tunableTuple13 = tunableVariant9.Get<TunableTuple>("statistic_set_in_range");
                tunableTuple13.Set<TunableBasic>("stat", "16657");
                var tunableVariant10 = tunableTuple13.Set<TunableVariant>("value_type", "int_range");
                var tunableTuple14 = tunableVariant10.Get<TunableTuple>("int_range");
                var tunableTuple15 = tunableTuple14.Get<TunableTuple>("value_range");
                tunableTuple15.Set<TunableBasic>("lower_bound", "75");
                tunableTuple15.Set<TunableBasic>("upper_bound", "100");
            }

            var context = new SituationJobExportContext
            {
                Element = this,
                Tuning = tuning
            };
            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(SituationJobComponent)))
            {
                AddComponent(type);
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetComponent<SituationJobInfoComponent>();
            info.Name = new Base.PropertyTypes.STBLString() { CustomText = label };
        }
    }
}