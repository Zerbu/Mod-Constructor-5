using Constructor5.Base.Startup;
using Constructor5.Core;
using System;
using System.Linq;

namespace Constructor5.Base.ElementSystem
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ElementTypeDataAttribute : StartupTypeAttribute
    {
        public ElementTypeDataAttribute()
        {
        }

        public ElementTypeDataAttribute(string label, bool canBeCreated)
        {
            Label = label;
            CanBeCreatedByUser = canBeCreated;
        }

        public bool CanBeCreatedByUser { get; set; }
        public Type[] ElementTypes { get; set; }
        public bool IsRootType { get; set; }
        public string[] PresetFolders { get; set; }

        public override void Invoke(Type type)
        {
            var result = new ElementTypeData()
            {
                CanBeCreatedByUser = CanBeCreatedByUser,
                ElementTypes = ElementTypes?.ToArray(),
                IsRootType = IsRootType,
                Label = Label ?? type.Name,
                PresetFolders = PresetFolders?.ToArray(),
                Type = type
            };
            ContentRegistry.Register("ElementTypes", type.Name, result);
        }

        private string Label { get; }
    }
}