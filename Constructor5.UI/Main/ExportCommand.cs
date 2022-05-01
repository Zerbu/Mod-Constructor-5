using Constructor5.Base.ExportSystem;
using Constructor5.Base.ProjectSystem;
using Constructor5.UI.Bases;
using Microsoft.Win32;

namespace Constructor5.UI.Main
{
    public class ExportCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var packageFile = ShowPackageFilePrompt();

            if (packageFile != null)
            {
                Exporter.StartExport(packageFile);
            }

            //ShowExportCompleteDialog();
        }

        private string ShowPackageFilePrompt()
        {
            var saveFileDialog = new SaveFileDialog()
            {
                Filter = "Package Files|*.package"
            };
            saveFileDialog.FileName = Project.Id;

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }
    }
}
