using Constructor5.UI.Bases;
using Microsoft.VisualBasic;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public class SetActionLabelCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var action = (BasicExtrasConditionGroupAction)parameter;

            var input = Interaction.InputBox("Set Label", "The Sims 4 Mod Constructor", action.Action.CustomLabel);
            if (string.IsNullOrEmpty(input))
            {
                action.Action.CustomLabel = null;
            }
            else
            {
                action.Action.CustomLabel = input;
            }
        }
    }
}
