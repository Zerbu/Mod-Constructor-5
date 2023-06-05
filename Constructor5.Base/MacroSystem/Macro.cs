using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    public class Macro
    {
        [XmlElement("Command")]
        [XmlElement("CreateElement", typeof(CreateElementMacroCommand))]
        [XmlElement("GetComponent", typeof(GetComponentMacroCommand))]
        [XmlElement("SetObject", typeof(SetObjectMacroCommand))]
        [XmlElement("SetText", typeof(SetTextMacroCommand))]
        [XmlElement("SetObjectVariable", typeof(SetObjectVariableMacroCommand))]
        [XmlElement("SetStringVariable", typeof(SetStringVariableMacroCommand))]
        [XmlElement("AddStringToList", typeof(AddStringToListMacroCommand))]
        public FastObservableCollection<MacroCommand> Commands { get; } = new FastObservableCollection<MacroCommand>();

        public void Run(MacroContext defaultContext = null)
        {
            if (defaultContext == null)
            {
                defaultContext = new MacroContext();
            }
            foreach(var command in Commands)
            {
                command.Run(defaultContext);
            }
        }

        public static Macro RunMacroFromFile(string file, Element contextElement)
        {
            var macro = (Macro)XmlLoader.LoadFile<Macro>(file);
            var context = new MacroContext();
            context.Variables.Add("_DataContext", contextElement);
            context.Variables.Add("_Element", contextElement);
            macro.Run(context);
            return macro;
        }
    }
}
