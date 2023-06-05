using Constructor5.Base.Icons;
using Constructor5.Core;
using System.Reflection;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public class SetIconMacroCommand : SetPropertyMacroCommand
    {
        [XmlAttribute]
        public string Value { get; set; }

        protected override object GetNewValue(MacroContext context, PropertyInfo propInfo) => new ElementIcon((string)context.ParseVariable(Value));
    }
}
