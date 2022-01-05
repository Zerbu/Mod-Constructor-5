using Constructor5.Elements.Interactions.Social;
using Constructor5.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.Interactions.Shared
{
    [XmlSerializerExtraType]
    public abstract class InteractionTemplate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [XmlIgnore]
        public abstract string Label { get; }

        protected internal abstract void OnExport(InteractionExportContext context);
    }
}