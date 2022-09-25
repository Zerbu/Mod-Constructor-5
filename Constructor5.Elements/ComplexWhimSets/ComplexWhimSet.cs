using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;
using Constructor5.Elements.SimpleWhimSets;
using Constructor5.Elements.SituationGoals;

namespace Constructor5.Elements.ComplexWhimSets
{
    [ElementTypeData("ComplexWhimSet", true, ElementTypes = new[] { typeof(ComplexWhimSet) }, IsRootType = true)]
    public class ComplexWhimSet : Element, IExportableElement, ISupportsCustomTuning
    {
        [AutoTuneBasic("activated_priority")]
        public double ActivatedPriority { get; set; } = 6;

        [AutoTuneReferenceList("objectives")]
        public ReferenceList ActivationObjectives { get; set; } = new ReferenceList();

        [AutoTuneBasic("chained_priority")]
        public double ChainedPriority { get; set; } = 11;

        [AutoTuneBasic("cooldown_timer")]
        public double CooldownTimer { get; set; } = 60;

        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        [AutoTuneBasic("priority_decay_rate")]
        public double PriorityDecayRate { get; set; } = 0.00833;

        [AutoTuneBasic("whim_reason")]
        public STBLString Reason { get; set; } = new STBLString() { CustomText = "(From Custom Complex Whim Set)" };

        public bool RecheckOnTimeout { get; set; }

        public ReferenceList Whims { get; set; } = new ReferenceList();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "AspirationWhimSet";
            tuning.InstanceType = "aspiration";
            tuning.Module = "whims.whim_set";

            AutoTunerInvoker.Invoke(this, tuning);

            var list = tuning.Get<TunableList>("whims");
            foreach(var whim in Whims.GetOfType<WeightedWhimReferenceListItem>())
            {
                foreach(var whimKey in ElementTuning.GetInstanceKeys(whim.Reference))
                {
                    var tuple = list.Get<TunableTuple>(null);
                    tuple.Set<TunableBasic>("whim", whimKey);
                    if (whim.Weight != 1)
                    {
                        tuple.Set<TunableBasic>("weight", whim.Weight);
                    }
                }
            }

            if (RecheckOnTimeout)
            {
                tuning.Set<TunableBasic>("timeout_retest", ActivationObjectives.Items[0].Reference);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}