using Constructor5.Base.Startup;
using System;

namespace Constructor5.UI.Dialogs.ObjectTypeSelector
{
    public class ObjectTypeExtraTabAttribute : StartupTypeAttribute
    {
        public ObjectTypeExtraTabAttribute(string registryCategory) => RegistryCategory = registryCategory;

        public string RegistryCategory { get; }

        public override void Invoke(Type type) => ObjectTypeExtraTabManager.AddTab(RegistryCategory, type);
    }
}