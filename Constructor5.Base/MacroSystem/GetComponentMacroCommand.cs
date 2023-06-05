using Constructor5.Base.ComponentSystem;
using Constructor5.Core;
using System.Collections;
using System.Xml.Serialization;

namespace Constructor5.Base.MacroSystem
{
    [XmlSerializerExtraType]
    public class GetComponentMacroCommand : MacroCommand
    {
        [XmlAttribute]
        public string ListVariable { get; set; } = "Components";
        [XmlAttribute]
        public string TypeName { get; set; }

        protected internal override void Run(MacroContext context)
        {
            var newContext = new MacroContext(context);

            var componentElement = (IHasComponents)context.GetVariable("_Element");

            var allComponents = (IList)componentElement.GetType().GetProperty(ListVariable).GetValue(componentElement);
            foreach(var component in allComponents)
            {
                var typedComponent = (ElementComponent)component;
                if (component.GetType().Name == TypeName)
                {
                    newContext.SetVariable("_Component", typedComponent);
                    newContext.SetVariable("_DataContext", typedComponent);
                    break;
                }
            }

            if (newContext.GetVariable("_Component") != null)
            {
                RunChildCommands(newContext);
            }
        }
    }
}
