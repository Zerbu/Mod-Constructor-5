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

        [XmlIgnore]
        public string Label => CustomLabel ?? GeneratedLabel;

        string IHasSettableLabel.SettableLabel
        {
            get => CustomLabel;
            set => CustomLabel = value;
        }

        protected internal abstract string GetVariantTunableName();

        protected internal abstract void OnExportVariant(TunableBase variantTunable);

        protected internal virtual void OnExportMain(TuningBase tunable, string tunableName = null)
        {
            var variantTunableName = GetVariantTunableName();
            var variantTunable = tunable.Set<TunableVariant>(tunableName, variantTunableName);
            OnExportVariant(variantTunable);
        }

        protected void InvokePropertyChanged(PropertyChangedEventArgs eventArgs) => PropertyChanged?.Invoke(this, eventArgs);
    }
}