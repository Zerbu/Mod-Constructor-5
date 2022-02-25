using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Base.LocalizationSystem;

namespace Constructor5.Base.CustomTuning
{
    [ElementTypeData("CustomTuningElement", true, ElementTypes = new[] { typeof(CustomTuningElement) }, IsRootType = true)]
    public class CustomTuningElement : Element, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        public void OnExport()
        {
            var tuning = ElementTuning.Create(this);

            CustomTuningExporter.Export(this, tuning, CustomTuning);

            if (string.IsNullOrEmpty(tuning.InstanceType))
            {
                Exporter.Current.AddError(this, $"{{nl}}{TextStringManager.Get("CustomTuningInstanceTypeNotSet").Replace("{id}", UserFacingId)}");
            }

            if (string.IsNullOrEmpty(tuning.Module))
            {
                Exporter.Current.AddError(this, $"{{nl}}{TextStringManager.Get("CustomTuningModuleNotSet").Replace("{id}", UserFacingId)}");
            }

            if (string.IsNullOrEmpty(tuning.Class))
            {
                Exporter.Current.AddError(this, $"{{nl}}{TextStringManager.Get("CustomTuningClassNotSet").Replace("{id}", UserFacingId)}");
            }

            if (tuning.InstanceType == null)
            {
                return;
            }

            TuningExport.AddToQueue(tuning);
        }
    }
}
