using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.InteractionTemplates.Romance
{
    [SelectableObjectType("SocialInteractionTemplates", "FlirtyIntroductionInteraction")]
    [XmlSerializerExtraType]
    public class FlirtyIntroductionTemplate : RomanceSITemplate
    {
        public FlirtyIntroductionTemplate() => TuningActionsFile = "FlirtyIntroduction";

        public override string Label => "FlirtyIntroductionInteraction";
    }
}