using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.Elements.Whims;

namespace Constructor5.Elements.SituationGoals
{
    [ElementTypeData("SituationGoal", true, ElementTypes = new[] { typeof(SituationGoal) }, PresetFolders = new[] { "SituationGoal" })]
    public class SituationGoal : SimpleComponentElement<SituationGoalComponent>, IExportableElement, IMultiTuningElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        ulong[] IMultiTuningElement.GetInstanceKeys(out bool hasMultiTuning)
        {
            var template = GetComponent<SituationGoalTemplateComponent>().Template;
            if (template is SituationGoalMultiGenerator multiGenerator)
            {
                hasMultiTuning = true;
                return multiGenerator.GetInstanceKeys(new SituationGoalExportContext
                {
                    Element = this
                });
            }

            hasMultiTuning = false;
            return new ulong[0];
        }

        void IExportableElement.OnExport()
        {
            var template = GetComponent<SituationGoalTemplateComponent>().Template;

            if (template is SituationGoalMultiGenerator)
            {
                template.OnExport(new SituationGoalExportContext()
                {
                    Element = this
                });
            }
            else
            {
                var tuning = SituationGoalTuner.CreateTuning(this, new SituationGoalExportContext()
                {
                    Element = this
                });
                if (GetContextModifier<WhimGoalContextModifier>() != null)
                {
                    var tunableList1 = tuning.Get<TunableList>("_goal_loot_list");
                    tunableList1.Set<TunableBasic>(null, "272907");
                    tunableList1.Set<TunableBasic>(null, "291795");
                }
                CustomTuningExporter.Export(this, tuning, CustomTuning);
                TuningExport.AddToQueue(tuning);
            }
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetSubtypes(typeof(SituationGoalComponent)))
            {
                AddComponent(type);
            }
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetComponent<SituationGoalInfoComponent>();
            info.Name = new Base.PropertyTypes.STBLString() { CustomText = label };
        }
    }
}