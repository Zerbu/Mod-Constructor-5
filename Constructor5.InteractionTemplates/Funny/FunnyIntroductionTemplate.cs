using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.InteractionTemplates.Funny
{
    [SelectableObjectType("SocialInteractionTemplates", "FunnyIntroductionInteraction")]
    [XmlSerializerExtraType]
    public class FunnyIntroductionTemplate : FunnySITemplate
    {
        public FunnyIntroductionTemplate() => TuningActionsFile = "FunnyIntroduction";

        public override string Label => "FunnyIntroductionInteraction";
    }
}
