using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.AutoTuners;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.PropertyTypes;

namespace Constructor5.Elements.SimpleWhimSets
{
    [ElementTypeData("SimpleWhimSet", true, ElementTypes = new[] { typeof(SimpleWhimSet) }, IsRootType = true, PresetFolders = new[] { "ObjectivelessWhimSet" })]
    public class SimpleWhimSet : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        [AutoTuneBasic("priority")]
        public double Priority { get; set; } = 10;

        [AutoTuneBasic("whim_reason")]
        public STBLString Reason { get; set; } = new STBLString() { CustomText = "(From Custom Want and Fear Set)" };

        public ReferenceList Whims { get; set; } = new ReferenceList();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "ObjectivelessWhimSet";
            tuning.InstanceType = "aspiration";
            tuning.Module = "whims.whim_set";

            AutoTunerInvoker.Invoke(this, tuning);

            var list = tuning.Get<TunableList>("whims");
            foreach (var whim in Whims.GetOfType<WeightedWhimReferenceListItem>())
            {
                foreach (var whimKey in ElementTuning.GetInstanceKeys(whim.Reference))
                {
                    var tuple = list.Get<TunableTuple>(null);
                    tuple.Set<TunableBasic>("whim", whimKey);
                    if (whim.Weight != 1)
                    {
                        tuple.Set<TunableBasic>("weight", whim.Weight);
                    }
                }
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}
