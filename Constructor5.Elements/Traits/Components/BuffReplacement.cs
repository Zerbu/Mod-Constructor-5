using Constructor5.Base.ElementSystem;

namespace Constructor5.Elements.Traits.Components
{
    public class BuffReplacement
    {
        public Reference OriginalBuff { get; set; } = new Reference();
        public Reference ReplacementBuff { get; set; } = new Reference(26440, "The default setting will block the buff altogether");
    }
}