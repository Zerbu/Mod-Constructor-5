using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.InteractionTemplates.Friendly
{
    [SelectableObjectType("SocialInteractionTemplates", "FriendlyIntroductionInteraction")]
    [XmlSerializerExtraType]
    public class FriendlyIntroductionTemplate : FriendlySITemplate
    {
        public FriendlyIntroductionTemplate() => TuningActionsFile = "FriendlyIntroduction";

        public override string Label => "FriendlyIntroductionInteraction";
    }
}