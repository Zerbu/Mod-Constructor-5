using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
