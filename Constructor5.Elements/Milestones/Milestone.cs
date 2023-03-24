using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Elements.SituationGoals;

namespace Constructor5.Elements.Milestones
{
    [ElementTypeData("Milestone", true, ElementTypes = new[] { typeof(Milestone) }, PresetFolders = new[] { "Milestone" }, IsRootType = true)]
    public class Milestone : SimpleComponentElement<MilestoneComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        public override bool Force31BitKey => true;

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "DevelopmentalMilestone";
            tuning.InstanceType = "developmental_milestone";
            tuning.Module = "developmental_milestones.developmental_milestone";

            var displayWhenNotUnlockedComponent = GetComponent<MilestoneDisplayWhenNotUnlocked>();

            tuning.SimDataHandler = displayWhenNotUnlockedComponent.DisplayWhenNotUnlocked
                ? new SimDataHandler($"SimData/MilestoneDisplayWhenNotUnlocked.data")
                : new SimDataHandler($"SimData/Milestone.data");

            var context = new MilestoneExportContext
            {
                Element = this,
                Tuning = tuning,
                SimDataOffset = displayWhenNotUnlockedComponent.DisplayWhenNotUnlocked ? 64 : 0,
                SimDataAgesPosition = displayWhenNotUnlockedComponent.DisplayWhenNotUnlocked ? 288 : 192
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

            var goalComponent = GetComponent<MilestoneGoal>();
            if (goalComponent.Goal != null)
            {
                return;
            }

            var newGoal = ElementManager.Create(typeof(SituationGoal), null, true);
            newGoal.AddContextModifier(new MilestoneContextModifier() { Milestone = new Reference(this) });
            goalComponent.Goal = new Reference(newGoal);
        }
    }
}