using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using System.Collections.Generic;

namespace Constructor5.Base.MacroSystem
{
    public class MacroContext
    {
        public MacroContext()
        {
        }

        public MacroContext(MacroContext existing)
        {
            foreach (var kvp in existing.Variables)
            {
                Variables.Add(kvp.Key, kvp.Value);
            }
        }

        public Dictionary<string, object> Variables { get; } = new Dictionary<string, object>();

        public object GetVariable(string key)
        {
            if (Variables.ContainsKey(key))
            {
                return Variables[key];
            }

            return null;
        }

        public object ParseVariable(string str)
        {
            if (!str.StartsWith("$"))
            {
                return str;
            }

            var split = str.Substring(1);
            return GetVariable(split);
        }

        public void SetVariable(string key, object value)
        {
            if (!Variables.ContainsKey(key))
            {
                Variables.Add(key, value);
                return;
            }

            Variables[key] = value;
        }
    }
}