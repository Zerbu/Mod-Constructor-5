using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.Milestones;
using Constructor5.Elements.SituationGoals;
using Constructor5.Elements.SituationGoals.Components;
using Constructor5.Elements.SituationGoals.Templates;
using Constructor5.Elements.TestConditions;
using Constructor5.TestConditionTypes;
using Constructor5.TestConditionTypes.Statistics;
using System;

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

        public STBLString NameLocked { get; set; } = new STBLString();
        public STBLString NameLockedMin { get; set; } = new STBLString();
        public STBLString NameLockedMax { get; set; } = new STBLString();
        public ReferenceList PreferredTraits { get; set; } = new ReferenceList();
        public ReferenceList BlacklistedTraits { get; set; } = new ReferenceList();

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

                var milestoneInfo = milestone.GetComponent<MilestoneInfo>();
                milestoneInfo.AllowInfant = false;
                milestoneInfo.IsRepeatable = false;
                milestoneInfo.AllowToddler = false;
                milestoneInfo.PlaySoundEffect = false;

                TuneDisplayWhenNotUnlocked(milestone, i);

                Exporter.Current.AddContextSpecificElement(milestone);
            }
        }

        private void TuneDisplayWhenNotUnlocked(Milestone milestone, int level)
        {
            var component = milestone.GetComponent<MilestoneDisplayWhenNotUnlocked>();
            component.DisplayWhenNotUnlocked = true;
            component.NameWhenNotUnlocked = NameLocked;
            component.DescriptionsWhenNotUnlocked = new STBLString() { CustomText = "{0.SimFirstName} is ready to work on a skill." };

            var traitItem = new TestConditionListItem();

            var traitCondition = new TraitCondition();
            traitItem.Condition = traitCondition;

            foreach(var whitelist in PreferredTraits.Items)
            {
                traitCondition.Whitelist.Items.Add(whitelist);
            }
            foreach (var blacklist in BlacklistedTraits.Items)
            {
                traitCondition.Blacklist.Items.Add(blacklist);
            }

            component.Conditions.Add(traitItem);

            var statItem = new TestConditionListItem();

            var statCondition = new StatisticCondition
            {
                Statistic = Skill,
                Threshold = new Threshold(level-1, level == 2 ? ThresholdComparison.LESS_OR_EQUAL : ThresholdComparison.EQUAL)
            };
            statItem.Condition = statCondition;

            component.Conditions.Add(statItem);

            // preferred traits
            // blacklisted traits
        }
    }
}
