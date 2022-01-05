using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Core
{
    public static class Hooks
    {
        public static void Location<T>(Action<T> action) where T : IHook
        {
            var type = typeof(T);

            if (!Dictionary.ContainsKey(type))
            {
                Dictionary.Add(type, new HashSet<IHook>());
            }

            foreach (var hook in Dictionary[type].ToArray())
            {
                action.Invoke((T)hook);
            }
        }

        public static void RegisterClass(IHook obj)
        {
            foreach (var iface in obj.GetType().GetInterfaces())
            {
                if (typeof(IHook).IsAssignableFrom(iface))
                {
                    if (!Dictionary.ContainsKey(iface))
                    {
                        Dictionary.Add(iface, new HashSet<IHook>());
                    }

                    if (!Dictionary[iface].Contains(obj))
                    {
                        Dictionary[iface].Add(obj);
                    }
                }
            }
        }

        public static void UnregisterClass(IHook obj)
        {
            foreach (var iface in obj.GetType().GetInterfaces())
            {
                if (typeof(IHook).IsAssignableFrom(iface))
                {
                    if (Dictionary.ContainsKey(iface))
                    {
                        Dictionary.Remove(iface);
                    }
                }
            }
        }

        private static Dictionary<Type, HashSet<IHook>> Dictionary { get; } = new Dictionary<Type, HashSet<IHook>>();
    }
}