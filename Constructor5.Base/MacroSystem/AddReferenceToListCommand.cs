using Constructor5.Base.ElementSystem;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    public class AddReferenceToListCommand : MacroCommand
    {
        [XmlAttribute]
        public string On { get; set; } = "_DataContext";

        [XmlAttribute]
        public string Property { get; set; }

        [XmlAttribute]
        public ulong GameReference { get; set; }

        [XmlAttribute]
        public string GameReferenceLabel { get; set; }

        [XmlAttribute]
        public bool Clear { get; set; }

        protected internal override void Run(MacroContext context)
        {
            var obj = context.GetVariable(On);
            var list = (ReferenceList)obj.GetType().GetProperty(Property).GetValue(obj);
            if (Clear)
            {
                list.Items.Clear();
            }

            if (GameReference != 0)
            {
                var item = new ReferenceListItem
                {
                    Reference = new Reference(GameReference, GameReferenceLabel)
                };
                list.Items.Add(item);
            }
        }
    }
}
