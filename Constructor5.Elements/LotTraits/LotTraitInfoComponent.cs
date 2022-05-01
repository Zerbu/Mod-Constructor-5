using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;
using Constructor5.Core;

namespace Constructor5.Elements.LotTraits
{
    [XmlSerializerExtraType]
    public class LotTraitInfoComponent : LotTraitComponent
    {
        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "LotTraitInfo";

        public STBLString Description { get; set; } = new STBLString();
        public ElementIcon Icon { get; set; } = new ElementIcon();
        public bool IsLotChallenge { get; set; }
        public STBLString Name { get; set; } = new STBLString();

        protected internal override void OnExport(LotTraitExportContext context)
        {
            if (Exporter.Current.STBLBuilder == null)
            {
                return;
            }

            var uiInfoTuning = ElementTuning.Create(Element, "UIInfo");
            uiInfoTuning.Class = "ZoneModifierDisplayInfo";
            uiInfoTuning.InstanceType = "user_interface_info";
            uiInfoTuning.Module = "zone_modifier.zone_modifier_display_info";
            uiInfoTuning.SimDataHandler = new SimDataHandler($"SimData/LotTraitUI.data");
            TuneUIInfo(uiInfoTuning, context);
        }

        private void TuneUIInfo(TuningHeader uiInfoTuning, LotTraitExportContext context)
        {
            uiInfoTuning.Set<TunableBasic>("zone_modifier_description", Description);
            uiInfoTuning.Set<TunableBasic>("zone_modifier_icon", Icon);
            uiInfoTuning.Set<TunableBasic>("zone_modifier_name", Name);
            uiInfoTuning.Set<TunableBasic>("zone_modifier_reference", ElementTuning.GetSingleInstanceKey(context.Element));

            uiInfoTuning.SimDataHandler.WriteText(88 + 8, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            uiInfoTuning.SimDataHandler.WriteText(64 + 8, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
            uiInfoTuning.SimDataHandler.WriteTGI(72 + 8, Icon.GetUncommentedText(), Element);
            uiInfoTuning.SimDataHandler.Write(96 + 8, ElementTuning.GetSingleInstanceKey(context.Element) ?? 0);

            if (IsLotChallenge)
            {
                uiInfoTuning.Set<TunableEnum>("modifier_type", "LOT_CHALLENGE");
                uiInfoTuning.SimDataHandler.Write(64, true);
            }

            TuningExport.AddToQueue(uiInfoTuning);
        }
    }
}