using Constructor5.Base.Startup;
using System;

namespace Constructor5.UI.Shared
{
    public class ObjectEditorAttribute : StartupTypeAttribute
    {
        public ObjectEditorAttribute(Type objectType, string category = "Default")
        {
            ObjectType = objectType;
            Category = category;
        }

        public string Category { get; }
        public Type ObjectType { get; }

        public override void Invoke(Type type) => ObjectEditorManager.SetEditorType(ObjectType, type, Category);
    }
}