using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.Base.DebugCommandSystem
{
    public abstract class DebugCommandBase
    {
        public abstract void Invoke(string[] parameters);
    }
}
