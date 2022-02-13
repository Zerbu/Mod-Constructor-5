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

        public event PropertyChangedEventHandler PropertyChanged;

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