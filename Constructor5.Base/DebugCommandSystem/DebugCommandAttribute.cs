using Constructor5.Base.Startup;
using System;

namespace Constructor5.Base.DebugCommandSystem
{
    public class DebugCommandAttribute : StartupTypeAttribute
    {
        public DebugCommandAttribute(string name) => Name = name;

        public override void Invoke(Type type)
            => DebugCommandManager.Register(Name, (DebugCommandBase)Activator.CreateInstance(type));

        private string Name { get; }
    }
}