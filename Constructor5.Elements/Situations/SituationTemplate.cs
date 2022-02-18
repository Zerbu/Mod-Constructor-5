using Constructor5.Core;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.Situations
{
    [XmlSerializerExtraType]
    public abstract class SituationTemplate : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        [XmlIgnore]
        public abstract string Label { get; }

        protected internal abstract void OnExport(SituationExportContext context);
    }
}
