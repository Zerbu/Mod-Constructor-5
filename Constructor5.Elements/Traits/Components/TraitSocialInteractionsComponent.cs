using Constructor5.Base.ElementSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;

namespace Constructor5.Elements.Traits.Components
{
    [XmlSerializerExtraType]
    public class TraitSocialInteractionsComponent : TraitComponent
    {
        public override string ComponentLabel => "SocialInteractions";

        public ReferenceList SocialInteractions { get; set; } = new ReferenceList();

        protected internal override void OnExport(TraitExportContext context)
        {
            if (!SocialInteractions.HasItems())
            {
                return;
            }

            var tunableList1 = context.Tuning.Get<TunableList>("actor_mixers");
            var tunableTuple1 = tunableList1.Get<TunableTuple>(null);
            tunableTuple1.Set<TunableBasic>("key", "13998");
            var tunableList2 = tunableTuple1.Get<TunableList>("value");

            foreach (var key in ElementTuning.GetInstanceKeys(SocialInteractions))
            {
                tunableList2.Set<TunableBasic>(null, key);
            }
        }
    }
}
