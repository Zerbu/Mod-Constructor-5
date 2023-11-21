using Constructor5.UI.Shared;
using System.Windows.Controls;

namespace Constructor5.MultiMilestones
{
    [ObjectEditor(typeof(SkillMilestones))]
    public partial class SkillMilestonesEditor : UserControl, IObjectEditor
    {
        public SkillMilestonesEditor() => InitializeComponent();

        void IObjectEditor.SetObject(object obj, string tag)
        {
            DataContext = obj;
        }

        private void QuickSetButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var element = (SkillMilestones)DataContext;
            element.NameMin.CustomText = $"Learned the {element.SkillName.CustomText} Skill";
            element.Name.CustomText = $"Reached Level # {element.SkillName.CustomText} Skill";
            element.NameMax.CustomText = $"Mastered the {element.SkillName.CustomText} Skill";

            element.DescriptionMin.CustomText = $"{{0.SimFirstName}} increased {{M0.his}}{{F0.her}} {element.SkillName.CustomText} skill at {{3.String}}.";
            element.Description.CustomText = $"{{0.SimFirstName}} increased {{M0.his}}{{F0.her}} {element.SkillName.CustomText} skill at {{3.String}}.";
            element.DescriptionMax.CustomText = $"{{0.SimFirstName}} increased {{M0.his}}{{F0.her}} {element.SkillName.CustomText} skill at {{3.String}}.";

            element.NameLockedMin.CustomText = $"Learn the {element.SkillName.CustomText} Skill";
            element.NameLocked.CustomText = $"Level Up the {element.SkillName.CustomText} Skill";
            element.NameLockedMax.CustomText = $"Master the {element.SkillName.CustomText} Skill";
        }
    }
}