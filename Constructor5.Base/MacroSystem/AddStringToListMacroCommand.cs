using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    public class AddStringToListMacroCommand : MacroCommand
    {
        [XmlAttribute]
        public string On { get; set; } = "_DataContext";

        [XmlAttribute]
        public string Property { get; set; }

        [XmlAttribute]
        public string Value { get; set; }

        [XmlAttribute]
        public bool Clear { get; set; }

        protected internal override void Run(MacroContext context)
        {
            var obj = context.GetVariable(On);
            var propInfo = obj.GetType().GetProperty(Property);
            var list = (ObservableCollection<string>)propInfo.GetValue(obj);
            if (Clear)
            {
                list.Clear();
            }
            list.Add(Value);
        }
    }
}
