using Constructor5.Base.ElementSystem;
using Constructor5.Base.MacroSystem;
using Constructor5.Core;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public class CreateElementMacroCommand : MacroCommand
    {
        [XmlAttribute]
        public string TypeName { get; set; }
        [XmlAttribute]
        public string ElementName { get; set; }
        [XmlAttribute]
        public string GuidOverride { get; set; }

        protected internal override void Run(MacroContext context)
        {
            var newContext = new MacroContext(context);
            var element = ElementManager.Create(Reflection.GetTypeByName(TypeName), ElementName, false, GuidOverride);
            newContext.SetVariable("_DataContext", element);
            newContext.SetVariable("_Element", element);
            RunChildCommands(newContext);
        }
    }
}