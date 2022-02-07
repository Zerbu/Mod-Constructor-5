using System.Collections.Generic;

namespace Constructor5.Base.DebugCommandSystem
{
    public static class DebugCommandManager
    {
        public static void Invoke(string name, string[] parameters) => Commands[name].Invoke(parameters);

        public static void Register(string name, DebugCommandBase command)
                    => Commands.Add(name, command);

        private static Dictionary<string, DebugCommandBase> Commands { get; } = new Dictionary<string, DebugCommandBase>();
    }
}