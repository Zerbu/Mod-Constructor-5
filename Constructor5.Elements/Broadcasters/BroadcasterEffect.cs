using Constructor5.Base.PropertyTypes;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.Broadcasters
{
    public abstract class BroadcasterEffect : INotifyPropertyChanged, IHasSettableLabel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [XmlAttribute]
        public string CustomLabel { get; set; }

        [XmlAttribute]
        public string GeneratedLabel { get; set; }

        [XmlIgnore]
        public string Label => CustomLabel ?? GeneratedLabel;

        string IHasSettableLabel.SettableLabel
        {
            get => CustomLabel;
            set => CustomLabel = value;
        }

        protected internal abstract void OnExport(BroadcasterExportContext originalContext);

        //protected internal abstract void OnExport(LASExportContext originalContext);
    }
}