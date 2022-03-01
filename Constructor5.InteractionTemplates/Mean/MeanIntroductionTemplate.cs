using Constructor5.Base.SelectableObjects;
using Constructor5.Core;

namespace Constructor5.InteractionTemplates.Mean
{
    [SelectableObjectType("SocialInteractionTemplates", "MeanIntroductionInteraction")]
    [XmlSerializerExtraType]
    public class MeanIntroductionTemplate : MeanSITemplate
    {
        public MeanIntroductionTemplate() => TuningActionsFile = "MeanIntroduction";

        public override string Label => "MeanIntroductionInteraction";
    }
}