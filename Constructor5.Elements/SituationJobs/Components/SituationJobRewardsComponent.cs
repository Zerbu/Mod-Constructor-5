using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Xml;

namespace Constructor5.Elements.SituationJobs.Components
{
    [XmlSerializerExtraType]
    public class SituationJobRewardsComponent : SituationJobComponent
    {
        public override string ComponentLabel => "Actions";

        public ReferenceList NoMedalLoot { get; set; } = new ReferenceList();
        public ReferenceList BronzeLoot { get; set; } = new ReferenceList();
        public ReferenceList SilverLoot { get; set; } = new ReferenceList();
        public ReferenceList GoldLoot { get; set; } = new ReferenceList();

        protected internal override void OnExport(SituationJobExportContext context)
        {
            var tunableList1 = context.Tuning.Get<TunableList>("rewards");
            TuneLoot(tunableList1, "BRONZE", BronzeLoot);
            TuneLoot(tunableList1, "SILVER", SilverLoot);
            TuneLoot(tunableList1, "GOLD", GoldLoot);
            TuneLoot(tunableList1, "TIN", NoMedalLoot);
        }

        private void TuneLoot(TunableList tunableList1, string medalLevel, ReferenceList referenceList)
        {
            if (referenceList.HasItems())
            {
                var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
                tunableTuple1.Set<TunableEnum>("medal", medalLevel);
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("benefit");
                var tunableList2 = tunableTuple2.Get<TunableList>("loot");
                foreach (var loot in ElementTuning.GetInstanceKeys(referenceList))
                {
                    tunableList2.Set<TunableBasic>(null, loot);
                }
            }
        }
    }
}
