using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.PropertyTypes;
using Constructor5.Base.SelectableObjects;
using Constructor5.Core;
using Constructor5.Elements.DramaNodes;
using System.Collections.ObjectModel;

namespace Constructor5.DramaNodeTemplates
{
    [SelectableObjectType("DramaNodeTemplates", "DialogDramaNodeTemplate")]
    [XmlSerializerExtraType]
    public class DialogDramaNodeTemplate : DramaNodeTemplate
    {
        public override string Label => "Dialog Drama Node";

        public ObservableCollection<DramaNodeTextVariant> Variants { get; set; } = new ObservableCollection<DramaNodeTextVariant>();

        public bool AllowChild { get; set; } = true;
        public bool AllowTeen { get; set; } = true;
        public bool AllowYoungAdult { get; set; } = true;
        public bool AllowAdult { get; set; } = true;
        public bool AllowElder { get; set; } = true;


        protected override void OnExport(DramaNodeExportContext context)
        {
            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("dialog_and_loot", "dialog_ok");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("dialog_ok");
                var tunableTuple2 = tunableTuple1.Get<TunableTuple>("dialog");
                tunableTuple2.Set<TunableEnum>("phone_ring_type", "BUZZ");
                var tunableVariant2 = tunableTuple2.Set<TunableVariant>("text", "variation");
                var tunableTuple3 = tunableVariant2.Get<TunableTuple>("variation");
                var tunableList1 = tunableTuple3.Get<TunableList>("variations");

                foreach (var variant in Variants)
                {
                    tunableList1.Set<TunableBasic>(null, variant.Text);
                }
            }

            {
                var tunableList1 = context.Tuning.Get<TunableList>("receiver_sim_pretests");
                var tunableList2 = tunableList1.Get<TunableList>(null);
                var tunableVariant1 = tunableList2.Set<TunableVariant>(null, "sim_info");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("sim_info");
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("ages", "specified");
                var tunableList3 = tunableVariant2.Get<TunableList>("specified");

                if (AllowChild)
                {
                    tunableList3.Set<TunableEnum>(null, "CHILD");
                }
                if (AllowTeen)
                {
                    tunableList3.Set<TunableEnum>(null, "TEEN");
                }
                if (AllowYoungAdult)
                {
                    tunableList3.Set<TunableEnum>(null, "YOUNGADULT");
                }
                if (AllowAdult)
                {
                    tunableList3.Set<TunableEnum>(null, "ADULT");
                }
                if (AllowElder)
                {
                    tunableList3.Set<TunableEnum>(null, "ELDER");
                }
                
                var tunableVariant3 = tunableTuple1.Set<TunableVariant>("species", "specified");
                var tunableTuple2 = tunableVariant3.Get<TunableTuple>("specified");
                var tunableList4 = tunableTuple2.Get<TunableList>("species");
                tunableList4.Set<TunableEnum>(null, "");
            }

            {
                var tunableVariant1 = context.Tuning.Set<TunableVariant>("sender_sim_info", "participant_type");
                var tunableTuple1 = tunableVariant1.Get<TunableTuple>("participant_type");
                tunableTuple1.Set<TunableEnum>("participant_type", "TargetSim");
            }
        }
    }
}
