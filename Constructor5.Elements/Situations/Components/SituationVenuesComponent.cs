using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Xml;

namespace Constructor5.Elements.Situations.Components
{
    [XmlSerializerExtraType]
    public class SituationVenuesComponent : SituationComponent
    {
        public override string ComponentLabel => "Lot Types";

        public bool IncludeGuestLots { get; set; } = true;
        public bool IncludeGenericLots { get; set; } = true;

        [AutoTuneReferenceList("compatible_venues")]
        public ReferenceList OtherAllowedVenues { get; set; } = new ReferenceList();

        protected internal override void OnExport(SituationExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("compatible_venues");

            if (IncludeGuestLots)
            {
                tunableList1.Set<TunableBasic>(null, "28614");
            }
            
            if (IncludeGenericLots)
            {
                tunableList1.Set<TunableBasic>(null, "9279");
            }

            AutoTunerInvoker.Invoke(this, context.Tuning);
        }
    }
}
