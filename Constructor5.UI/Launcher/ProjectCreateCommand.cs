using Constructor5.Base;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using Constructor5.UI.Bases;

namespace Constructor5.UI.Launcher
{
    public class ProjectCreateCommand : CommandBase
    {
        public string CreatorName { get; set; }
        public string ModName { get; set; }

        public override bool CanExecute(object parameter) => !string.IsNullOrEmpty(CreatorName) && !string.IsNullOrEmpty(ModName);

        public override void Execute(object parameter)
        {
            ProgramSettings.CreatorName = CreatorName;
            ProgramSettings.Save();
            ProjectManager.Create(CreatorName, ModName);
        }
    }
}