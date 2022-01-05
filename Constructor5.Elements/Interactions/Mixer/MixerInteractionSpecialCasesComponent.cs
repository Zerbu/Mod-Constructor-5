using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Elements.Interactions.Shared;
using Constructor5.Core;

namespace Constructor5.Elements.Interactions.Mixer
{
    [MixerInteractionComponent]
    [XmlSerializerExtraType]
    public class MixerInteractionSpecialCasesComponent : InteractionComponent
    {
        public override string ComponentLabel => "Special Cases";

        public bool IsIdle { get; set; }

        protected internal override void OnExport(InteractionExportContext context)
        {
            if (IsIdle)
            {
                {
                    var tunableTuple1 = context.Tuning.Get<TunableTuple>("progress_bar_enabled");
                    tunableTuple1.Set<TunableBasic>("bar_enabled", "False");
                    var tunableTuple2 = context.Tuning.Get<TunableTuple>("sub_action");
                    tunableTuple2.Set<TunableBasic>("base_weight", "5");
                    tunableTuple2.Set<TunableEnum>("mixer_group", "IDLES");

                    context.Tuning.Set<TunableVariant>("basic_focus", "do_not_change_focus");
                }

                {
                    var tunableList1 = context.Tuning.Get<TunableList>("test_globals");
                    var tunableVariant1 = tunableList1.Set<TunableVariant>(null, "buff");
                    var tunableTuple1 = tunableVariant1.Get<TunableTuple>("buff");
                    var tunableList2 = tunableTuple1.Get<TunableList>("blacklist");
                    tunableList2.Set<TunableBasic>(null, "256563");
                    var tunableVariant2 = tunableList1.Set<TunableVariant>(null, "mood");
                    var tunableTuple2 = tunableVariant2.Get<TunableTuple>("mood");
                    tunableTuple2.Set<TunableBasic>("disallow", "True");
                    tunableTuple2.Set<TunableBasic>("mood", "201531");
                }
            }
        }
    }
}