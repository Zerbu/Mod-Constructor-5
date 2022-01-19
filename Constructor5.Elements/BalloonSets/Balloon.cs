using Constructor5.Base.Icons;

namespace Constructor5.Elements.BalloonSets
{
    public class Balloon
    {
        public bool HasOverlay { get; set; }
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public int Weight { get; set; } = 1;
    }
}