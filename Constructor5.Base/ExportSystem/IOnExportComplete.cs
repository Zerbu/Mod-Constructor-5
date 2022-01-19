using Constructor5.Core;

namespace Constructor5.Base.ExportSystem
{
    public interface IOnExportComplete : IHook
    {
        void OnExportComplete(ExportResultsData results);
    }
}