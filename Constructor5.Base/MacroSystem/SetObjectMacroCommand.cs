using Constructor5.Core;
using System.Reflection;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public class SetObjectMacroCommand : SetPropertyMacroCommand
    {
        [XmlAttribute]
        public string Value { get; set; }

        [XmlAttribute]
        public bool IgnoreIfSameType { get; set; }

        protected override object GetNewValue(MacroContext context, PropertyInfo propInfo)
        {
            var obj = context.GetVariable(On);
            var newValue = context.ParseVariable(Value);

            var currentValue = GetCurrentValue(context);
            var currentType = currentValue.GetType();
            var newType = newValue.GetType();
            if (IgnoreIfSameType && currentType == newType)
            {
                return currentValue;
            }

            return newValue;
        }
    }
}
