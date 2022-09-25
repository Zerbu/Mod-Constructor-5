using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.Python;
using Constructor5.Elements.EnumExtensions.PythonSteps;

namespace Constructor5.Elements.EnumExtensions
{
    [ElementTypeData("EnumExtension", true, ElementTypes = new[] { typeof(EnumExtension) }, IsRootType = true)]
    public class EnumExtension : SimpleComponentElement<EnumExtensionComponent>, IExportableElement
    {
        void IExportableElement.OnExport()
        {
            var context = new EnumExtensionExportContext
            {
                Element = this
            };
            PythonBuilder.AddStep(AddEnumInjectorPythonStep.Current);
            foreach (var component in Components)
            {
                component.OnExport(context);
            }
        }
    }
}
