using Constructor5.Core;
using System.Reflection;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public abstract class SetPropertyMacroCommand : MacroCommand
    {
        [XmlAttribute]
        public string On { get; set; } = "_DataContext";

        [XmlAttribute]
        public string Property { get; set; }

        protected internal override void Run(MacroContext context)
        {
            var obj = GetOnVariable(context);
            var propInfo = GetPropertyInfo(context);

            var newValue = GetNewValue(context, propInfo);
            propInfo.SetValue(obj, newValue);

            var newContext = new MacroContext(context);
            newContext.SetVariable("_DataContext", newValue);

            RunChildCommands(newContext);
        }

        protected object GetCurrentValue(MacroContext context) => GetPropertyInfo(context).GetValue(GetOnVariable(context));

        protected abstract object GetNewValue(MacroContext context, PropertyInfo propInfo);

        protected object GetOnVariable(MacroContext context)
        {
            return context.GetVariable(On);
        }

        protected PropertyInfo GetPropertyInfo(MacroContext context)
        {
            return GetOnVariable(context).GetType().GetProperty(Property);
        }
    }
}