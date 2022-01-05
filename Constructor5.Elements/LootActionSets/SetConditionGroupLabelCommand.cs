using Constructor5.UI.Bases;
using Microsoft.VisualBasic;

namespace Constructor5.Elements.LootActionSets
{
    public class SetConditionGroupLabelCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var group = (LASConditionGroup)parameter;

            var input = Interaction.InputBox("Set Label", "The Sims 4 Mod Constructor", group.Condition.CustomLabel);
            if (string.IsNullOrEmpty(input))
            {
                group.Condition.CustomLabel = null;
            }
            else
            {
                group.Condition.CustomLabel = input;
            }
        }
    }
}
