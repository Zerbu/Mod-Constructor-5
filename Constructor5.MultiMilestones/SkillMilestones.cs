using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Milestones;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.TestConditionTypes.Statistics;

namespace Constructor5.MultiMilestones
{
    [ElementTypeData("{nl}Multi-Milestones: Skills", true, ElementTypes = new[] { typeof(SkillMilestones) }, IsRootType = true)]
    public class SkillMilestones : Element, IExportableElement
    {
        public STBLString Description { get; set; } = new STBLString();
        public STBLString DescriptionMin { get; set; } = new STBLString();
        public STBLString DescriptionMax { get; set; } = new STBLString();
        public STBLString Name { get; set; } = new STBLString();
        public STBLString NameMin { get; set; } = new STBLString();
        public STBLString NameMax { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public int LevelMax { get; set; } = 10;
        public Reference Skill { get; set; } = new Reference();
        public STBLString SkillName { get; set; } = new STBLString();

        void IExportableElement.OnExport()
        {
            for (int i = 2; i <= LevelMax; i++)
            {
                var milestone = ElementManager.CreateTemporary<Milestone>();
                milestone.UserFacingId = $"{UserFacingId}:{i}";

                var milestoneGoalComponent = milestone.GetComponent<MilestoneGoal>();
                var goal = (SituationGoal)milestoneGoalComponent.Goal.Element;

                var goalInfo = goal.GetComponent<SituationGoalInfoComponent>();
                if (i == 2)
                {
                    goalInfo.Name = NameMin;
                    goalInfo.Description = DescriptionMin;
                    goalInfo.Icon = Icon;
                }
                else if (i == LevelMax)
                {
                    goalInfo.Name = NameMax;
                    goalInfo.Description = DescriptionMax;
                    goalInfo.Icon = Icon;
                }
                else
                {
                    goalInfo.Name.CustomText = Name.CustomText.Replace("#", i.ToString());
                    goalInfo.Description = Description;
                    goalInfo.Icon = Icon;
                }

                goalInfo.ShowLocation = true;

                var template = new SituationGoalActorTemplate();
                goal.GetComponent<SituationGoalTemplateComponent>().Template = template;

                var statCondition = new StatisticCondition();
                template.PrimaryCondition = statCondition;

                statCondition.Statistic = Skill;
                statCondition.Threshold = new Threshold(i, ThresholdComparison.GREATER_OR_EQUAL);

                Exporter.Current.AddContextSpecificElement(milestone);
            }
        }
    }
}
