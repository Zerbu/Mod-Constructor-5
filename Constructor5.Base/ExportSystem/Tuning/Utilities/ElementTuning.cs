using Constructor5.Base.ElementSystem;
using Constructor5.Base.ProjectSystem;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Base.ExportSystem.Tuning.Utilities
{
    public static class ElementTuning
    {
        public static TuningHeader Create(Element element, string suffix = null) => Create<TuningHeader>(element, suffix);

        public static TuningHeader Create<T>(Element element, string suffix = null) where T : TuningHeader, new()
        {
            var result = new T()
            {
                Name = GetFullName(element, suffix)
            };
            if (string.IsNullOrEmpty(suffix))
            {
                result.InstanceKey = (ulong)GetSingleInstanceKey(element);
            }
            else
            {
                result.InstanceKey = GetInstanceKeyFromName(element, suffix);
            }
            return result;
        }

        public static string GetFullName(Element element, string suffix = null)
        {
            var result = $"{Project.Id}_{element.UserFacingId}";
            if (!string.IsNullOrEmpty(suffix))
            {
                result += $":{suffix}";
            }
            return result;
        }

        public static ulong GetInstanceKeyFromName(Element element, string suffix) => FNVHasher.FNV32(GetFullName(element, suffix), true);

        public static ulong[] GetInstanceKeys(Reference reference)
        {
            if (reference.Element != null)
            {
                return GetInstanceKeys(reference.Element);
            }

            if (reference.GameReference != 0)
            {
                return new[] { reference.GameReference };
            }

            return new ulong[0];
        }

        public static ulong[] GetInstanceKeys(ReferenceList list)
        {
            var result = new List<ulong>();

            foreach (var item in list.Items)
            {
                result.AddRange(GetInstanceKeys(item.Reference));
            }

            return result.ToArray();
        }

        // This returns an array in case the ability for an element to produce multiple keys for references is added in the future
        public static ulong[] GetInstanceKeys(Element element, string suffix = null)
        {
            if (element.IsContextSpecific)
            {
                Exporter.Current.AddContextSpecificElement(element);
            }

            if (element is IMultiTuningElement multiTuningElement)
            {
                var result = multiTuningElement.GetInstanceKeys(out var hasMultiTuning);
                if (hasMultiTuning)
                {
                    return result;
                }
            }
            else if (element.InstanceKeyOverride != null)
            {
                return new[] { element.InstanceKeyOverride ?? 0 };
            }

            return new[] { GetInstanceKeyFromName(element, suffix) };
        }

        public static ulong? GetSingleInstanceKey(Element element)
        {
            var keys = GetInstanceKeys(element);
            if (keys.Count() > 0)
            {
                return keys[0];
            }

            return null;
        }

        public static ulong? GetSingleInstanceKey(Reference reference)
        {
            var keys = GetInstanceKeys(reference);
            if (keys.Count() > 0)
            {
                return keys[0];
            }

            return null;
        }
    }
}