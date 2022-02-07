using System;
using System.ComponentModel;

namespace Constructor5.UI.Shared
{
    [Obsolete]
    public class EnumToStringConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => (sourceType.Equals(typeof(Enum)));

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => (destinationType.Equals(typeof(String)));

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) => base.ConvertFrom(context, culture, value);

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (!destinationType.Equals(typeof(String)))
            {
                throw new ArgumentException("Can only convert to string.", "destinationType");
            }

            if (!value.GetType().BaseType.Equals(typeof(Enum)))
            {
                throw new ArgumentException("Can only convert an instance of enum.", "value");
            }

            string name = value.ToString();
            object[] attrs =
                value.GetType().GetField(name).GetCustomAttributes(typeof(EnumDisplayTextAttribute), false);
            return (attrs.Length > 0) ? ((EnumDisplayTextAttribute)attrs[0]).DisplayText : name;
        }
    }
}