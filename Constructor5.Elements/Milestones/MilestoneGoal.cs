using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;

namespace Constructor5.Elements.Milestones
{
    [XmlSerializerExtraType]
    public class MilestoneGoal : MilestoneComponent
    {
        public override int ComponentDisplayOrder => 10;
        public override string ComponentLabel => "Goal";

        public Reference Goal { get; set; } // do not add = new Reference();

        protected internal override void OnExport(MilestoneExportContext context)
        {
            var goalElement = (SituationGoal)Goal.Element;
            var goalInfo = goalElement.GetComponent<SituationGoalInfoComponent>();

            var header = (TuningHeader)context.Tuning;
            header.Set<TunableBasic>("name", goalInfo.Name);
            header.Set<TunableBasic>("unlocked_text", goalInfo.Description);
            
            header.Set<TunableBasic>("icon", goalInfo.Icon);
            context.Tuning.Set<TunableBasic>("goal", Goal);

            var contextlessDescription = goalInfo.Description;
            if (!string.IsNullOrEmpty(goalInfo.ContextlessDescription.CustomText))
            {
                contextlessDescription = goalInfo.ContextlessDescription;
            }
            header.Set<TunableBasic>("unlocked_text_no_context", contextlessDescription);

            if (Exporter.Current.STBLBuilder != null)
            {
                header.SimDataHandler.WriteText(context.SimDataOffset + 168, Exporter.Current.STBLBuilder.GetKey(goalInfo.Name) ?? 0);
                header.SimDataHandler.WriteText(context.SimDataOffset + 176, Exporter.Current.STBLBuilder.GetKey(goalInfo.Description) ?? 0);
                header.SimDataHandler.WriteText(context.SimDataOffset + 180, Exporter.Current.STBLBuilder.GetKey(contextlessDescription) ?? 0);
                header.SimDataHandler.WriteTGI(context.SimDataOffset + 144, goalInfo.Icon.GetUncommentedText(), Element);
            }
        }
    }
}
