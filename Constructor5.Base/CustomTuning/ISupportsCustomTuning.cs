using Constructor5.Base.Export;

namespace Constructor5.Base.CustomTuning
{
    public interface ISupportsCustomTuning : IExportableElement
    {
        CustomTuningInfo CustomTuning { get; set; }
    }
}