using Constructor5.Base.ExportSystem.Tuning;

namespace Constructor5.Elements.Interactions.Shared
{
    public abstract class InteractionExportContext
    {
        public InteractionElement Element { get; set; }
        public ulong? LearnTraitLootKey { get; set; }
        public ulong TraitKey { get; set; }
        public TuningBase Tuning { get; set; }
    }
}