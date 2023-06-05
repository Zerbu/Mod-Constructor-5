using Constructor5.Base.PropertyTypes;
using Constructor5.Core;
using System.Reflection;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{

    [XmlSerializerExtraType]
    public class SetTextMacroCommand : SetPropertyMacroCommand
    {
        [XmlAttribute]
        public string Value { get; set; }

        protected override object GetNewValue(MacroContext context, PropertyInfo propInfo)
        {
            var stblString = (STBLString)propInfo.GetValue(context.GetVariable(On));
            stblString.CustomText = Value;
            return stblString;
        }
    }
}
