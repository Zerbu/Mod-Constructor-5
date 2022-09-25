using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.SituationGoals;

namespace Constructor5.Elements.Whims
{
    [ElementTypeData("Whim", true, ElementTypes = new[] { typeof(Whim) }, IsRootType = false, PresetFolders = new[] { "Whim" }, ImportTuningType = "whim")]
    public class Whim : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        [AutoTuneBasic("fluff_description")]
        public STBLString FluffDescription { get; set; } = new STBLString();

        [AutoTuneBasic("goal")]
        public Reference Goal { get; set; } = new Reference();

        public WhimTypes WhimType { get; set; } = WhimTypes.ShortTerm;

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "Whim";
            tuning.InstanceType = "whim";
            tuning.Module = "whims.whim";

            AutoTunerInvoker.Invoke(this, tuning);

            var chanceMultiplier = 1.5;
            var whimTypeValue = "ERROR";
            switch (WhimType)
            {
                case WhimTypes.LongTerm:
                    whimTypeValue = "LONG_TERM";
                    break;
                case WhimTypes.ShortTerm:
                    whimTypeValue = "SHORT_TERM";
                    break;
                case WhimTypes.Reactionary:
                    whimTypeValue = "REACTIONARY";
                    break;
                case WhimTypes.FearConfrontation:
                    chanceMultiplier = 50;
                    whimTypeValue = "CONFRONTATION";
                    break;
            }

            var tunableVariant1 = tuning.Set<TunableVariant>("chaining_whimset_chance_multiplier", "enabled");
            tunableVariant1.Set<TunableBasic>("enabled", chanceMultiplier);
            tuning.Set<TunableEnum>("type", whimTypeValue);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}