using Constructor5.Base.Startup;
using System;

namespace Constructor5.Base.ExportSystem.TuningActions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RegisterTuningActionAttribute : StartupTypeAttribute
    {
        public RegisterTuningActionAttribute(string key) => Key = key;

        public string Key { get; }

        public override void Invoke(Type type) => TuningActionRegistry.Content.Add(Key, type);
    }
}