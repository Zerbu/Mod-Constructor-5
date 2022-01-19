using Constructor5.Base.Startup;
using Constructor5.Core;
using System;

namespace Constructor5.Base.SelectableObjects
{
    public class SelectableObjectTypeAttribute : StartupTypeAttribute
    {
        public SelectableObjectTypeAttribute(string registryCategory, string displayName)
        {
            RegistryCategory = registryCategory;
            DisplayName = displayName;
        }

        public string Description { get; set; }
        public string DisplayName { get; }
        public string RegistryCategory { get; }

        public override void Invoke(Type type)
        {
            var existing = ContentRegistry.Get<SelectableObjectType>(RegistryCategory, type.Name);
            if (existing != null)
            {
                throw new Exception($"Selectable object {existing.DisplayName} is already assigned");
            }

            ContentRegistry.Register(RegistryCategory, type.Name, new SelectableObjectType
            {
                RegistryCategory = RegistryCategory,
                Description = Description,
                DisplayName = DisplayName,
                Type = type
            });
        }
    }
}