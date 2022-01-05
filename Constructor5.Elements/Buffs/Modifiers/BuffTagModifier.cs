namespace Constructor5.Elements.Buffs.Modifiers
{
    public class BuffTagModifier : BuffModifierBase
    {
        public string Tag { get; set; }
        public int IntValue
        {
            get => int.TryParse(Value.ToString(), out var result) ? result : 0;
            set => Value = value;
        }
        public double Value { get; set; } = 1;
    }
}
