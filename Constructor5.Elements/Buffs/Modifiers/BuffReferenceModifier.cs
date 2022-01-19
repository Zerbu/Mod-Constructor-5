using Constructor5.Base.ElementSystem;

namespace Constructor5.Elements.Buffs.Modifiers
{
    public class BuffReferenceModifier : BuffModifierBase
    {
        //public BuffModifierDirection Direction { get; set; } = BuffModifierDirection.Increase;
        public Reference Reference { get; set; } = new Reference();
        public int IntValue
        {
            get => (int)Value;
            set => Value = (double)value;
        }
        public double Value { get; set; } = 1;
    }
}
