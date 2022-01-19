using System;

namespace Constructor5.Base.Startup
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class StartupTypeAttribute : Attribute
    {
        public virtual int Priority => 0;
        public abstract void Invoke(Type type);
    }
}
