using Constructor5.Core;
using System.Reflection;

namespace Constructor5.Base.Startup
{
    public static class StartupEvents
    {
        public static void OnStartup() => TypeActions();

        public static void TypeActions()
        {
            ContentRegistry.Initialize();
            foreach (var type in Reflection.GetTypesWithAttribute<StartupTypeAttribute>(false))
            {
                foreach (var attribute in type.GetCustomAttributes<StartupTypeAttribute>())
                {
                    try
                    {
                        attribute.Invoke(type);
                    }
                    catch(System.Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }
                }
            }
        }
    }
}
