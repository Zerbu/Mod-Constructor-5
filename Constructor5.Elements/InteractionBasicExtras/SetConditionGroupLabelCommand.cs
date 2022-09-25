using Constructor5.UI.Bases;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.InteractionBasicExtras
{
    public class SetConditionGroupLabelCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var group = (BasicExtrasConditionGroup)parameter;

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
