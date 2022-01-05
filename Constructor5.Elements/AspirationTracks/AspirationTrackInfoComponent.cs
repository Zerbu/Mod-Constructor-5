using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Xml;

namespace Constructor5.Elements.AspirationTracks
{
    [XmlSerializerExtraType]
    public class AspirationTrackInfoComponent : AspirationTrackComponent
    {
        public STBLString AspirationCompleteNotification { get; set; } = new STBLString() { CustomText = "{0.SimFirstName} completed the aspiration! Yay!" };
        public Reference CASTrait { get; set; } = new Reference();

        [AutoTuneBasic("category")]
        public Reference Category { get; set; } = new Reference();

        public override string ComponentLabel => "Aspiration Track Info";

        [AutoTuneBasic("description_text")]
        public STBLString Description { get; set; } = new STBLString();

        public bool HasCustomCASTrait { get; set; }

        [AutoTuneBasic("icon")]
        public ElementIcon Icon { get; set; } = new ElementIcon();

        public bool IsChildAspiration { get; set; }

        [AutoTuneBasic("display_text")]
        public STBLString Name { get; set; } = new STBLString();

        [AutoTuneBasic("reward")]
        public Reference Reward { get; set; } = new Reference();

        protected internal override void OnExport(AspirationTrackExportContext context)
        {
            AutoTunerInvoker.Invoke(this, context.Tuning);

            context.Tuning.Set<TunableBasic>("primary_trait", HasCustomCASTrait ? CASTrait : GetDefaultCASTrait());

            {
                var tunableTuple1 = context.Tuning.Get<TunableTuple>("notification");
                var tunableVariant1 = tunableTuple1.Set<TunableVariant>("text", "single");
                tunableVariant1.Set<TunableBasic>("single", AspirationCompleteNotification);
                var tunableVariant2 = tunableTuple1.Set<TunableVariant>("title", "enabled");
                tunableVariant2.Set<TunableBasic>("enabled", "0xC107F668");
                var tunableList1 = tunableTuple1.Get<TunableList>("ui_responses");
                var tunableTuple2 = tunableList1.Get<TunableTuple>(null);
                tunableTuple2.Set<TunableBasic>("text", "0x7E8E7CD3");
                tunableTuple2.Set<TunableEnum>("ui_request", "SHOW_ASPIRATION_SELECTOR");
                tunableTuple1.Set<TunableEnum>("urgency", "DEFAULT");
            }

            var header = (TuningHeader)context.Tuning;

            header.SimDataHandler.WriteText(148, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            header.SimDataHandler.WriteText(144, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
            header.SimDataHandler.WriteTGI(152, Icon.GetUncommentedText());

            header.SimDataHandler.Write(136, ElementTuning.GetSingleInstanceKey(Category) ?? 0);

            var casTraitKey = (ulong)ElementTuning.GetSingleInstanceKey(HasCustomCASTrait ? CASTrait : GetDefaultCASTrait());
            header.SimDataHandler.Write(200, casTraitKey);

            header.SimDataHandler.Write(208, ElementTuning.GetSingleInstanceKey(Reward) ?? 0);
        }

        private Reference GetDefaultCASTrait()
        {
            switch (ElementTuning.GetSingleInstanceKey(Category))
            {
                case 171754:
                    return new Reference(171824);

                case 25113:
                    return new Reference(27080);

                case 25545:
                    return new Reference(27085);

                case 25382:
                    return new Reference(27084);

                case 25782:
                    return new Reference(27083);

                case 9638:
                    return new Reference(26197);

                case 25150:
                    return new Reference(27082);

                case 25385:
                    return new Reference(27086);

                case 144382:
                    return new Reference(144199);

                case 9637:
                    return new Reference(26200);

                case 40650:
                    return new Reference(35719);

                case 25278:
                    return new Reference(27087);

                default:
                    return new Reference();
            }
        }
    }
}