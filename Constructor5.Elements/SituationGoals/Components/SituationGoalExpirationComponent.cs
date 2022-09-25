using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Core;

namespace Constructor5.Elements.SituationGoals.Components
{
    [XmlSerializerExtraType]
    public class SituationGoalExpirationComponent : SituationGoalComponent
    {
        public override string ComponentLabel => "Expiration";

        public bool EnableExpiration { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        protected internal override void OnExport(SituationGoalExportContext context)
        {
            if (!EnableExpiration)
            {
                return;
            }

            var tunableVariant1 = context.Tuning.Set<TunableVariant>("expiration_time", "enabled");
            var tunableTuple1 = tunableVariant1.Get<TunableTuple>("enabled");
            var tunableTuple2 = tunableTuple1.Get<TunableTuple>("time");
            tunableTuple2.Set<TunableBasic>("hour", Hour);
            if (Minute != 0)
            {
                tunableTuple2.Set<TunableBasic>("minute", Minute);
            }
        }
    }
}
