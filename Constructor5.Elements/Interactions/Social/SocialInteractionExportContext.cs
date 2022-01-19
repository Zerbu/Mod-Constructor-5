using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.Interactions.Shared;

namespace Constructor5.Elements.Interactions.Social
{
    public class SocialInteractionExportContext : InteractionExportContext
    {
        public ulong? LearnTraitLootKey { get; set; }
        public ulong TraitKey { get; set; }
    }
}