using Constructor5.Base.ProjectSystem;
using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Constructor5.Base.ElementSystem
{
    public static class ElementManager
    {
        static ElementManager() => AllElements = new ReadOnlyObservableCollection<Element>(AllElementsCollection);

        public static ReadOnlyObservableCollection<Element> AllElements { get; }

        public static Element Create(Type type, string label, bool isContextSpecific = false)
        {
            var result = (Element)Reflection.CreateObject(type);
            result.Guid = GenerateGuid();
            result.UserFacingId = !isContextSpecific ? GenerateID(label) : GenerateID(result.Guid);
            result.IsContextSpecific = isContextSpecific;
            if (isContextSpecific)
            {
                result.ShowPreset = false;
            }
            Register(result);
            if (!isContextSpecific)
            {
                result.OnUserCreated(label);
            }
            Hooks.Location<IOnElementCreated>(x => x.OnElementCreated(result));
            return result;
        }

        public static T CreateTemporary<T>() where T : Element
        {
            var result = (T)Create(typeof(T), null, true);
            result.IsTemporary = true;
            return result;
        }

        public static void Delete(Element element)
        {
            element.IsDeleted = true;
            AllElementsCollection.Remove(element);
            File.Delete($"{Project.GetDirectory("Elements")}/{element.Guid}.{element.GetType().Name}.xml");
            Hooks.Location<IOnElementDeleted>(x => x.OnElementDeleted(element));
        }

        public static string GenerateID(string name)
        {
            var baseId = new Regex("[^a-zA-Z0-9-]").Replace(name, "");

            var idToUse = baseId;

            var num = 1;
            while (UsedUserFacingIds.Contains(idToUse))
            {
                num++;
                idToUse = $"{baseId}{num}";
            }

            return idToUse;
        }

        public static Element Get(string guid) => AllElements.FirstOrDefault(x => x.Guid == guid);

        public static Element[] GetAll(bool includeContextSpecific = true)
        {
            var result = AllElements.ToArray();
            if (!includeContextSpecific)
            {
                result = result.Where(x => !x.IsContextSpecific).ToArray();
            }
            return result;
        }

        public static void Register(Element element)
        {
            AllElementsCollection.Add(element);
            UsedGuids.Add(element.Guid);
            UsedUserFacingIds.Add(element.UserFacingId);
            element.OnElementCreatedOrLoaded();
        }

        internal static HashSet<string> UsedGuids { get; } = new HashSet<string>();
        internal static HashSet<string> UsedUserFacingIds { get; } = new HashSet<string>();

        private static ObservableCollection<Element> AllElementsCollection { get; set; } = new ObservableCollection<Element>();

        private static string GenerateGuid() => GuidUtility.GenerateGuid(UsedGuids);
    }
}