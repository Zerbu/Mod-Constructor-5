using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;

namespace Constructor5.Elements.Traits
{
    public interface ITraitComponent
    {
        int ComponentDisplayOrder { get; }
        Element Element { get; set; }
        string ComponentLabel { get; }
    }
}
