using Constructor5.Base.ElementSystem;
using System.Xml.Serialization;

namespace Constructor5.Base.ComponentSystem
{
    public abstract class ElementComponent : IElementComponent
    {
        [XmlIgnore]
        public abstract string ComponentLabel { get; }

        [XmlIgnore]
        public Element Element { get; set; }
    }
}
