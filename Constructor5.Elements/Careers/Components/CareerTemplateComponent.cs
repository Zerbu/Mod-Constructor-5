using Constructor5.Core;
using Constructor5.Elements.Careers.Templates;

namespace Constructor5.Elements.Careers.Components
{
    [XmlSerializerExtraType]
    public class CareerTemplateComponent : CareerComponent
    {
        public override string ComponentLabel => "CareerType";

        public CareerTemplateBase Template { get; set; } = new CareerTemplateFullTime();

        protected internal override void OnExport(CareerExportContext context)
            => Template?.OnExport(context);
    }
}
