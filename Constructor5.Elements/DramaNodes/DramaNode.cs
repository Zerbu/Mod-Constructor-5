using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Elements.DramaNodes
{
    [ElementTypeData("DramaNode", false, ElementTypes = new[] { typeof(DramaNode) }, PresetFolders = new[] { "DramaNode" }, IsRootType = true)]
    public class DramaNode : SimpleComponentElement<DramaNodeComponent>, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "DialogDramaNode";
            tuning.InstanceType = "drama_node";
            tuning.Module = "drama_scheduler.dialog_drama_node";

            var context = new DramaNodeExportContext
            {
                Element = this,
                Tuning = tuning
            };
            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }
    }
}
