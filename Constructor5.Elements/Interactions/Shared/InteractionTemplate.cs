using Constructor5.Elements.Interactions.Social;
using Constructor5.Core;
using System.ComponentModel;
using System.Xml.Serialization;
using Constructor5.Base.ExportSystem.TuningActions;

namespace Constructor5.Elements.Interactions.Shared
{
    [XmlSerializerExtraType]
    public abstract class InteractionTemplate : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        [XmlIgnore]
        public abstract string Label { get; }

        protected internal abstract void OnExport(InteractionExportContext context);

        protected void RunTuningActions(InteractionExportContext context, string actionsFile)
        {
            var tuningContext = new TuningActionContext
            {
                Tuning = context.Tuning,
                DataContext = this
            };
            tuningContext.Variables.Add("LearnTraitLootKey", context.LearnTraitLootKey?.ToString());
            TuningActionInvoker.InvokeFromFile($"Interactions/{actionsFile}", tuningContext);
        }

        protected internal virtual void OnSaveUpgrade(int oldVersion, int newVersion) { }
    }
}