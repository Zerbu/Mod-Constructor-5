using Constructor5.Base.Startup;
using Constructor5.Core;
using System;

namespace Constructor5.Elements.LootActionSets
{
    public class LootActionTypeAttribute : StartupTypeAttribute
    {
        public LootActionTypeAttribute(string displayName) => DisplayName = displayName;

        public string DisplayName { get; set; }

        public override void Invoke(Type type) => ContentRegistry.Register("LootActionTypes", type.Name, new LootActionType
        {
            DisplayName = DisplayName,
            Type = type
        });
    }
}
