/*using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Core;

namespace Constructor5.Elements.Careers.Components
{
    [XmlSerializerExtraType]
    public class CareerEventsComponent : CareerComponent
    {
        [AutoTuneReferenceList("career_events")]
        public ReferenceList CareerEvents { get; set; } = new ReferenceList();

        public override int ComponentDisplayOrder => 20;

        public override string ComponentLabel => "ActiveCareerEvents";

        protected internal override void OnExport(CareerExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}*/