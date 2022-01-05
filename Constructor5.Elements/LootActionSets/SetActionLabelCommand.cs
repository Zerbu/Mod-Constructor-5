using Constructor5.UI.Bases;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.LootActionSets
{
    public class SetActionLabelCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var action = (LASConditionGroupAction)parameter;

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
