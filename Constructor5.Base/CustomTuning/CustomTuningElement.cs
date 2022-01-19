using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning;
using Constructor5.Base.ExportSystem.Tuning.Utilities;

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
                Exporter.Current.AddError(this, $"Instance type is not set for Custom Tuning Element: {UserFacingId}.");
            }

            if (string.IsNullOrEmpty(tuning.Module))
            {
                Exporter.Current.AddError(this, $"Module is not set for Custom Tuning Element: {UserFacingId}.");
            }

            if (string.IsNullOrEmpty(tuning.Class))
            {
                Exporter.Current.AddError(this, $"Class is not set for Custom Tuning Element: {UserFacingId}.");
            }

            if (tuning.InstanceType == null)
            {
                return;
            }

            TuningExport.AddToQueue(tuning);
        }
    }
}
