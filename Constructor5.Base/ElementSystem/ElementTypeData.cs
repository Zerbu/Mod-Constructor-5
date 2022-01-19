using Constructor5.Core;
using System;

namespace Constructor5.Base.ElementSystem
{
    public class ElementTypeData
    {
        public bool CanBeCreatedByUser { get; set; }
        public Type[] ElementTypes { get; set; }
        public string Label { get; set; }
        public string[] PresetFolders { get; set; }
        public Type Type { get; set; }
        public bool IsRootType { get; set; }

        public static ElementTypeData Get(Type type) => ContentRegistry.Get<ElementTypeData>("ElementTypes", type.Name);
    }
}