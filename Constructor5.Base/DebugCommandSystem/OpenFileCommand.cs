using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using System.IO;

namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("file")]
    public class OpenFileCommand : ElementCommand
    {
        protected override void InvokeElementCommand(Element element)
        {
            var file = Path.GetFullPath($"{Project.GetProjectDirectory("Elements")}/{element.Guid}.{element.GetType().Name}.xml");
            System.Diagnostics.Process.Start(file);
        }
    }
}
