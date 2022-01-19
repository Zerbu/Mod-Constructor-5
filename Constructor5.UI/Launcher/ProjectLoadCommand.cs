using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using Constructor5.Core;
using Constructor5.UI.Bases;

namespace Constructor5.UI.Launcher
{
    public class ProjectLoadCommand : CommandBase
    {
        public override void Execute(object parameter) => ProjectManager.LoadProject((ProjectInfo)parameter);
    }
}