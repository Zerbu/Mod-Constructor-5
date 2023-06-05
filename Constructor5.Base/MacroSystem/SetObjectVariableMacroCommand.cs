using Constructor5.Core;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public class SetObjectVariableMacroCommand : MacroCommand
    {
        [XmlAttribute]
        public string VariableName { get; set; }

        [XmlAttribute]
        public string TypeName { get; set; }

        protected internal override void Run(MacroContext context)
        {
            context.SetVariable(VariableName, Reflection.CreateObject(Reflection.GetTypeByName(TypeName)));
        }
    }
}
