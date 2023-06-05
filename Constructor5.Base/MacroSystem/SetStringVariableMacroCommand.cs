using Constructor5.Core;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public class SetStringVariableMacroCommand : MacroCommand
    {
        [XmlAttribute]
        public string VariableName { get; set; }

        [XmlAttribute]
        public string Value { get; set; }

        protected internal override void Run(MacroContext context)
        {
            context.SetVariable(VariableName, Value);
        }
    }
}
