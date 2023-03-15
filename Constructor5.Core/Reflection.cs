using Constructor5.Base.ProjectSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Constructor5.Core
{
    public static class Reflection
    {
        public static MethodInfo[] Methods
        {
            get
            {
                if (_methodsInAssembly != null)
                {
                    return _methodsInAssembly;
                }

                var methods = new List<MethodInfo>();

                foreach (var type in Types)
                {
                    methods.AddRange(type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static));
                }

                _methodsInAssembly = methods.ToArray();

                return methods.ToArray();
            }
        }

        public static Type[] Types
        {
            get
            {
                if (_typesInAssembly != null)
                {
                    return _typesInAssembly;
                }

                var types = new List<Type>();
                foreach (var assembly in GetAssemblies())
                {
                    types.AddRange(assembly.GetTypes());
                }

                _typesInAssembly = types.ToArray();

                return types.ToArray();
            }
        }

        public static object CreateObject(Type type) => Activator.CreateInstance(type);

        public static T CreateObject<T>() => (T)CreateObject(typeof(T));

        public static MethodAttributeInfo[] GetMethodsWithAttribute<T>(bool shouldInherit) where T : Attribute
        {
            var result = new List<MethodAttributeInfo>();

            foreach (var method in Methods)
            {
                var attribute = method.GetCustomAttribute<T>();
                if (attribute != null)
                {
                    result.Add(new MethodAttributeInfo
                    {
                        Method = method,
                        Attribute = attribute
                    });
                }
            }

            return result.ToArray();
        }

        public static Type[] GetSubtypes(Type type) => Types.Where(x => !x.IsAbstract && type.IsAssignableFrom(x)).ToArray();

        public static Type GetTypeByName(string name) => Types.FirstOrDefault(x => x.Name == name);

        public static Type[] GetTypesWithAttribute<T>(bool shouldInherit) where T : Attribute => Types.Where(x => x.GetCustomAttributes<T>(shouldInherit).Count() > 0).ToArray();

        public struct MethodAttributeInfo
        {
            public Attribute Attribute { get; set; }
            public MethodInfo Method { get; set; }
        }

        private static MethodInfo[] _methodsInAssembly;
        private static Type[] _typesInAssembly;

        private static IEnumerable<Assembly> GetAssemblies()
        {
            var result = new List<Assembly>
            {
                Assembly.GetCallingAssembly(),
                Assembly.Load("Constructor5.Base"),
                Assembly.Load("Constructor5.Core"),
                Assembly.Load("Constructor5.Elements"),
                Assembly.Load("Constructor5.UI"),
                Assembly.Load("Constructor5.TestConditionTypes"),
                Assembly.Load("Constructor5.InteractionTemplates"),
                Assembly.Load("Constructor5.LootActionTypes"),
                Assembly.Load("Constructor5.SituationTemplates"),
                Assembly.Load("Constructor5.SimFilterTypes"),
                Assembly.Load("Constructor5.SituationGoalTemplates"),
                Assembly.Load("Constructor5.BasicExtraTypes"),
                 Assembly.Load("Constructor5.ZoneDirectorTemplates"),
            };

            var pluginsDir = DirectoryUtility.GetUserDirectory("Plugins");
            if (Directory.Exists(pluginsDir))
            {
                result.AddRange(Directory.GetFiles(pluginsDir, "*.dll").Select(file => Assembly.LoadFrom(Path.GetFullPath(file))));
            }
            /*else
            {
                var mainAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("Constructor5.DebugTools.FormGenerator", "Constructor5"));
                result.AddRange(Directory.GetFiles($"{mainAssemblyDirectory}/Plugins", "*.dll").Select(file => Assembly.LoadFrom(Path.GetFullPath(file))));
            }*/

            return result;
        }
    }
}