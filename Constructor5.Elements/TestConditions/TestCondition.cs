using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.TestConditions
{
    [XmlSerializerExtraType]
    public abstract class TestCondition : INotifyPropertyChanged, IHasSettableLabel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [XmlAttribute]
        public string CustomLabel { get; set; }

        [XmlAttribute]
        public string GeneratedLabel { get; set; }

        [XmlAttribute]
        public int SaveVersion { get; set; } = 1;

        [XmlIgnore]
        public string Label => CustomLabel ?? GeneratedLabel;

        string IHasSettableLabel.SettableLabel
        {
            get => CustomLabel;
            set => CustomLabel = value;
        }

        protected internal abstract string GetVariantTunableName(string contextTag = null);

        protected internal abstract void OnExportVariant(TunableBase variantTunable, string contextTag);

        protected internal virtual void OnExportMain(TuningBase tunable, string tunableName = null, string contextTag = null)
        {
            var variantTunableName = GetVariantTunableName(contextTag);
            var variantTunable = tunable.Set<TunableVariant>(tunableName, variantTunableName);
            OnExportVariant(variantTunable, contextTag);
        }

        protected void InvokePropertyChanged(PropertyChangedEventArgs eventArgs) => PropertyChanged?.Invoke(this, eventArgs);
    }
}