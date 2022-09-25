using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.Python;
using Constructor5.Elements.SimpleWhimSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.WhimSetExtensions
{
    [ElementTypeData("WhimSetExtension", true, ElementTypes = new[] { typeof(WhimSetExtension) }, IsRootType = true)]
    public class WhimSetExtension : Element, IExportableElement
    {
        public ReferenceList WhimSets { get; set; } = new ReferenceList();
        public ReferenceList Whims { get; set; } = new ReferenceList();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "ObjectivelessWhimSet";
            tuning.InstanceType = "aspiration";
            tuning.Module = "whims.whim_set";

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

            TuningExport.AddToQueue(tuning);

            foreach (var whimSet in ElementTuning.GetInstanceKeys(WhimSets))
            {
                PythonBuilder.AddStep(WhimSetExtensionPythonStep.Current);
                WhimSetExtensionPythonStep.Current.AddWhimSet(whimSet, ElementTuning.GetSingleInstanceKey(this).Value);
            }
        }
    }
}
