using Constructor5.Base.ElementSystem;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Base.ComponentSystem
{
    public abstract class ElementComponent : IElementComponent, INotifyPropertyChanged
    {
        [XmlIgnore]
        public abstract string ComponentLabel { get; }

        [XmlIgnore]
        public Element Element { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
