using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.SimData;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Icons;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.RelBits
{
    [ElementTypeData("RelBit", true, ElementTypes = new[] { typeof(RelBit) }, PresetFolders = new[] { "RelBit" })]
    public class RelBit : Element, IExportableElement
    {
        [AutoTuneBasic("bit_description")]
        public STBLString Description { get; set; } = new STBLString();

        public int Duration { get; set; } = 240;
        public bool HasFixedDuration { get; set; }

        [AutoTuneBasic("icon")]
        public ElementIcon Icon { get; set; } = new ElementIcon();

        public bool IsOneSided { get; set; }

        [AutoTuneIfFalse("visible")]
        public bool IsVisibleInUI { get; set; }

        [AutoTuneBasic("name")]
        public STBLString Name { get; set; } = new STBLString();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "RelationshipBit";
            tuning.InstanceType = "relbit";
            tuning.Module = "relationships.relationship_bit";

            tuning.InstanceTypeKeyOverride = "0904DF10";

            AutoTunerInvoker.Invoke(this, tuning);

            if (HasFixedDuration)
            {
                tuning.Set<TunableBasic>("timeout", Duration);
            }

            if (IsOneSided)
            {
                tuning.Set<TunableEnum>("directionality", "UNIDIRECTIONAL");
            }

            TuneSimData(tuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            Name = new STBLString() { CustomText = label };
        }

        private void TuneSimData(TuningHeader tuning)
        {
            tuning.SimDataHandler = new SimDataHandler("SimData/RelBit.data");

            tuning.SimDataHandler.WriteText(64, Exporter.Current.STBLBuilder.GetKey(Name) ?? 0);
            tuning.SimDataHandler.WriteText(76, Exporter.Current.STBLBuilder.GetKey(Description) ?? 0);
            tuning.SimDataHandler.WriteTGI(88, Icon.GetUncommentedText(), this);
        }
    }
}