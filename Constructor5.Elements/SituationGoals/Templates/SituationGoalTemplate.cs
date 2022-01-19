using Constructor5.Core;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Constructor5.Elements.SituationGoals.Templates
{
    [XmlSerializerExtraType]
    public abstract class SituationGoalTemplate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [XmlIgnore]
        public abstract string Label { get; }

        protected internal abstract void OnExport(SituationGoalExportContext context);
    }
}
