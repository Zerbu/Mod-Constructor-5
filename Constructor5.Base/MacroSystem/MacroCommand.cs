using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    public abstract class MacroCommand
    {
        [XmlElement("Command")]
        [XmlElement("CreateElement", typeof(CreateElementMacroCommand))]
        [XmlElement("GetComponent", typeof(GetComponentMacroCommand))]
        [XmlElement("SetObject", typeof(SetObjectMacroCommand))]
        [XmlElement("SetText", typeof(SetTextMacroCommand))]
        [XmlElement("SetObjectVariable", typeof(SetObjectVariableMacroCommand))]
        [XmlElement("SetStringVariable", typeof(SetStringVariableMacroCommand))]
        [XmlElement("AddStringToList", typeof(AddStringToListMacroCommand))]
        public FastObservableCollection<MacroCommand> ChildCommands { get; } = new FastObservableCollection<MacroCommand>();

        public void RunChildCommands(MacroContext context)
        {
            foreach (var command in ChildCommands)
            {
                command.Run(context);
            }
        }

        protected internal abstract void Run(MacroContext context);
    }
}
