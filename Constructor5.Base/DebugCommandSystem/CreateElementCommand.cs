using Constructor5.Base.ElementSystem;
using Constructor5.Core;

namespace Constructor5.Base.DebugCommandSystem
{
    [DebugCommand("create")]
    public class CreateElementCommand : DebugCommandBase
    {
        public override void Invoke(string[] parameters)
        {
            ElementManager.Create(Reflection.GetTypeByName(parameters[0]), parameters[1], false);
        }
    }
}
