using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;

namespace Constructor5.Elements.Careers.Components
{
    [XmlSerializerExtraType]
    public class CareerInteractionComponent : CareerComponent
    {
        public override string ComponentLabel => "CareerInteraction";

        public Reference Interaction { get; set; } // do not add = new Reference();

        protected internal override void OnExport(CareerExportContext context)
        {
            context.Tuning.Set<TunableBasic>("career_affordance", Interaction);
        }
    }
}
