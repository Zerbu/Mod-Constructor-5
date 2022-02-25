using Constructor5.Base.ComponentSystem;
using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Social;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.Interactions.Shared
{
    public abstract class InteractionElement : Element, IHasComponents
    {
        public List<InteractionComponent> Components { get; } = new List<InteractionComponent>();

        public T GetComponent<T>() where T : InteractionComponent => (T)Components.FirstOrDefault(x => x is T);

        ElementComponent[] IHasComponents.GetSortedUserFacingComponents()
                    => Components.OrderBy(x => ((IComponentDisplayOrder)x).ComponentDisplayOrder).ThenBy(x => x.ComponentLabel).ToArray();

        protected internal abstract void TuneTags(InteractionExportContext context);

        protected void AddComponent(Type type)
        {
            var component = Components.FirstOrDefault(x => x.GetType() == type);

            if (component == null)
            {
                component = (InteractionComponent)Reflection.CreateObject(type);
                Components.Add(component);
            }

            component.Element = this;
        }

        protected override void OnUserCreated(string label)
        {
            GeneratedLabel = label;
            var info = GetComponent<InteractionInfoComponent>();
            info.Name = new Base.PropertyTypes.STBLString() { CustomText = label };
        }
    }
}