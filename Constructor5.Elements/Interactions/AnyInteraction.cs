using Constructor5.Base.ElementSystem;
using Constructor5.Elements.Interactions.Mixer;
using Constructor5.Elements.Interactions.Social;
using Constructor5.Elements.Interactions.Super;

namespace Constructor5.Elements.Interactions
{
    [ElementTypeData(PresetFolders = new[] { "Interaction" }, ElementTypes = new[] { typeof(SocialInteraction), typeof(SuperInteraction), typeof(MixerInteraction) })]
    public class AnyInteraction : Element
    {
    }
}