using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using System.ComponentModel;

namespace Constructor5.Elements.Careers.Templates
{
    public class CareerTemplateMessageOverride : INotifyPropertyChanged, ITunableValueObject
    {
        public CareerTemplateMessageOverride()
        {
        }

        public CareerTemplateMessageOverride(string defaultText)
        {
            Override.CustomText = defaultText;
        }

#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        public bool IsMessageEnabled { get; set; }
        public STBLString Override { get; set; } = new STBLString();

        string ITunableValueObject.GetTunableValue()
        {
            if (!IsMessageEnabled)
            {
                return null;
            }

            return ((ITunableValueObject)Override).GetTunableValue();
        }
    }
}