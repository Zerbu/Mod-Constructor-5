using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.SimFilters
{
    public abstract class SimFilterTerm : INotifyPropertyChanged, IHasSettableLabel
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

        protected internal abstract void OnExport(TunableList filterTermsTunable);

        protected void InvokePropertyChanged(PropertyChangedEventArgs eventArgs) => PropertyChanged?.Invoke(this, eventArgs);
    }
}